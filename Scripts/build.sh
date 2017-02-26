#! /bin/sh

project="VRMaze"

echo "Building $project for Windows"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd)/VR\ Maze \
  -buildWindowsPlayer "$(pwd)/Build/windows/$project.exe" \
  -quit

echo "Logs:"
cat $(pwd)/unity.log

echo "Zipping builds"
zip -r $(pwd)/Build/windows.zip $(pwd)/Build/windows/

