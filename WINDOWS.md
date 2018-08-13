# Windows
We aim to support Windows as a work OS when dealing with our projects. This does
require some extra setup to avoid problems though.

## WSL
In later versions of Windows 10 there is the option to install a linux distro
and run it along side Windows in order to get access to a proper command line.
While not necessary we do tend to use bash scripts for automation so WSL is a
good idea to use.

## Line endings
Since Windows has it's own style of line endings while our projects are using
unix style line endings we need to setup git to respect this. Apply these
settings before cloning the project.

```
git config --global core.eol lf
git config --global core.autocrlf false
```

When setting up a new project it's worth noting that a .gitattributes file is
needed with the following settings.

```
* text=auto
```

## Case sensitivity
If you are using WSL (and why wouldn't you be?) case sensitivity is an issue in
newer versions of Windows 10. Case sensitive file systems aren't supported by
Unity at this point so we need to disable it for our project directories. This
can be done by running the following line in cmd.exe. Keep in mind that it
requires an empty directory so this should also be done before cloning the
project.

```
fsutil.exe file setCaseSensitiveInfo <path> disable
```

Unfortunately this doesn't solve all problems at this time. For that reason
the above advice should be ignored until Unity is fixed to support this change.
A workaround for now is to use the windows cmd.exe to clone the project repos.
After that it should be safe to use WSL for committing, pushing and pulling.
