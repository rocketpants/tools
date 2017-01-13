UNITY_PATH="/Applications/Unity/Unity.app/Contents/MacOS/Unity"
PROJECT_PATH="$(pwd)"
BUILD_PATH="$PROJECT_PATH/UnityPackages"
LOG_PATH="$PROJECT_PATH/Temp/export_package_log.txt"
NAME="$(basename `pwd`)"
VERSION="$(cat VERSION.txt)"
ASSETS="Assets/RocketPants"
EXPORT_PATH="$BUILD_PATH/$NAME-$VERSION.unitypackage"

$UNITY_PATH -batchmode -projectPath $PROJECT_PATH -exportPackage $ASSETS $EXPORT_PATH -logFile $LOG_PATH -quit
