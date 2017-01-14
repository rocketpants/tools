UNITY_PATH="/Applications/Unity/Unity.app/Contents/MacOS/Unity"
PROJECT_PATH="$(pwd)"

$UNITY_PATH -batchmode -projectPath $PROJECT_PATH -runEditorTests
