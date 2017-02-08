# Build pipeline
Since our pipeline is based on Jenkins there isn't a great way of keeping track
of it in case it has to be setup again. This document aims to capture the
process of setting up our build system.


## Installation

### [Jenkins.app](https://github.com/stisti/jenkins-app)
We use Jenkins for running build jobs, on Mac the easiest way to get going is
the Jenkins.app project which packages Jenkins in a Mac application and runs it
as your user.

### [Fastlane](https://github.com/fastlane/fastlane)
Fastlane is great for building and deploying mobile apps. We use it primarily
in order to build the exported xcode project from Unity into an .ipa file.


## Jenkins plugins
* [Unity3d plugin](http://wiki.jenkins-ci.org/display/JENKINS/Unity3dBuilder+Plugin)
For invoking Unity3D in command line mode.
* [Shared Workspace](http://wiki.jenkins-ci.org/display/JENKINS/Shared+workspace+plugin)
To avoid checking out the project once for each platform.
* [Environment Injector Plugin](https://wiki.jenkins-ci.org/display/JENKINS/EnvInject+Plugin)
Used for setting up the PATH.
* [Matrix Configuration Parameter Plugin](https://wiki.jenkins-ci.org/display/JENKINS/matrix+combinations+plugin)
Choose which parts of multi-configuration jobs to run.


## Jenkins config

### PATH setup
In order to use fastlane tools in Jenkins you need to add it to the PATH. Add a
file to the root of your jenkins installation (`~/.jenkins` if you're using
Jenkins.app), to add stuff to the PATH.

~/.jenkins/environment_variables.properties
```
PATH=$PATH:/Users/you/.fastlane/bin
```

Refer to this file under `Manage Jenkins -> Configure System -> Prepare jobs
environment -> Properties File Path`.

### Unity3d plugin
Add your Unity installation under `Manage Jenkins -> Global Tool Configuration
-> Unity3d installations`.

### Shared workspace
Add your repository URL to `Manage Jenkins ->
Configure System -> Workspace Sharing`. Since we don't have a SCM server we
refer to a local directory using the `file://` protocol. The reason we use a
shared workspace is because there is no need to checkout the repository once
for each platform that we are building for.


## Jenkins job setup
Our main build jobs are setup as Multi-configuration projects with the platform
setup as an axis. Setup one for each project that you want to build.

### SCM
The Repository URL is `${SHAREDSPACE_SCM_URL}` as per the Shared Workspace
plugin.

### Matrix parameter
Tick the box for `This project is parameterized` and add a single
`Matrix Combination Parameter` with the name `paramFilter`. This allows us to
decide which configurations you want to run when you start a build.

### Configuration matrix
We have two axises that allow the job to build to multiple platforms.

`BuildMethod` The method to be called on the `CustomBuildScript` class. Allowed
values:

* PerformAndroidBuild
* PerformiOSBuild
* PerformMacOSXBuild
* PerformWindowsBuild

`OutputPath` The directory where the final output file will be placed. This
only needs one value and as such perhaps shouldn't be an axis. Remember to set
this to a location outside of Dropbox since it generates a huge amount of files
that you don't want to be syncing.

### Build
First add a `Invoke Unity3d Editor` build step with the correct Unity
installation. The command line arguments are as follows:
```
-quit -batchmode -logFile "$WORKSPACE/unity3d_editor.log" -executeMethod CustomBuildScript.$BuildMethod $OutputPath
```

Next add a `Conditional step (single)` build step and set it to `Strings match`.
Compare the `${BuildMethod}` variable to the string `PerformiOSBuild`. As you
can probably guess this is the iOS build step. After building iOS we get an
xcode project that needs to be built. We do this using the `gym` command which
is part of Fastlane. Add the following shell script:

```
#!/bin/bash -l

echo "Running gym..."
gym -p ${OutputPath}/game-name-ios/Unity-iPhone.xcodeproj -o ${OutputPath} -n game-name-ios.ipa
```

