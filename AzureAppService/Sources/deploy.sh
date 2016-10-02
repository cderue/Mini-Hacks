# 1. KuduSync
echo "Kudu Sync"

# 2. Purge Symfony production cache
rm -r "$DEPLOYMENT_TARGET/var/cache/prod"

exitWithMessageOnError () {
  if [ ! $? -eq 0 ]; then
    echo "An error has occurred during web site deployment."
    echo $1
    exit 1
  fi
}
 
if [[ "$IN_PLACE_DEPLOYMENT" -ne "1" ]]; then
  "$KUDU_SYNC_CMD" -v 50 -f "$DEPLOYMENT_SOURCE" -t "$DEPLOYMENT_TARGET" -n "$NEXT_MANIFEST_PATH" -p "$PREVIOUS_MANIFEST_PATH" -i ".git;.hg;.deployment;deploy.sh"
  exitWithMessageOnError "Kudu Sync failed"
fi
 
# 3. Install dependencies
if [ -e "$DEPLOYMENT_TARGET/composer.json" ]; then
  echo "Install composer dependencies"
 
  # Getting composer path
  composerPath="$DEPLOYMENT_TARGET/composer.phar"
  if [[ ! -e $composerPath ]]; then
    echo "Composer file not found in the deployment root, downloading last version in a temp folder"
    composerPath="$DEPLOYMENT_TEMP/composer.phar"
    cd "$DEPLOYMENT_TEMP"
    php -r "readfile('https://getcomposer.org/installer');" | php
  fi
 
  # Getting composer arguments
  if [[ ! -n "$composerArgs" ]]; then
    composerArgs="--no-interaction --prefer-dist --optimize-autoloader --no-progress --no-dev --verbose"
    echo "No composer args found in App Settings, using the default: $composerArgs"
  fi
 
  # Using composer
  cd "$DEPLOYMENT_TARGET"
  
  export SYMFONY_ENV=prod
   
  php $composerPath install $composerArgs
  
  exitWithMessageOnError "Composer install failed"
fi