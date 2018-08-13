
A collection of scripts and tools that we made to help us in our daily work.


## Images and video for social media

### Scale a set of images for instagram video size.
```
convert -sample 640x640 sprite_**.png scaled_%02d.png
```

### Make an mp4 out of a series of png files.
```
ffmpeg -framerate 6 -i scaled_%02d.png -s:v 640x640 -c:v libx264 -profile:v high -crf 18 -pix_fmt yuv420p out.mp4

ffmpeg -start_number 0 -framerate 30 -i images/input_%04d.png -s:v 1920x1080 -c:v libx264 -profile:v high -crf 18 -pix_fmt yuv420p -vf vflip output.mp4

ffmpeg -start_number 0 -framerate 30 -i images/input_%04d.png -s:v 1080x1080 -c:v libx264 -profile:v high -crf 18 -pix_fmt yuv420p -vf vflip output.mp4

// Add -vframes 300 after -i to decide how many frames to encode.
```

### Crop a 1080p video to 1:1 aspect ratio
```
ffmpeg -i input.mp4 -filter:v "crop=1080:1080:420:0" -c:a copy output.mp4
```

### Compress video using x264 and aac.
```
ffmpeg -i input.mp4 -c:v libx264 -c:a aac -strict experimental -b:a 96k out.mp4
```

### Resize multiple images without scaling them.
```
mogrify *.png -background none -gravity south -extent 20x40 *.png
```

### Crop image to specific coordinates.
```
mogrify *.png -crop 10x10+32+32 +repage *.png
```

### Offset a bunch of images inside their canvas.
```
mogrify -page -3-3 -background none -flatten *.png
mogrify -page -3-3 -background none -flatten char4_idle_*.png
mogrify -page -3-3 -background none -flatten char4_walking_*.png
mogrify -page -3-3 -background none -flatten char4_wave_*.png
```


## Zip pre-release PC build
```
zip output.zip -x \*.DS_Store -r input
```


## Google Play translations
If you don't provide translations for the app description on Google Play it
will use Google Translate in non English markets. That is usually not a good
solution. One solution is to populate all translations with the English texts.

The code in `google-translations.js` automates this.


## Unity script templates for C# #
The C# templates are mostly to save some time when creating new script files.
At the moment the built in ones use tabs and some strange spacing rules, our
code style dictates 4 spaces and civilized spacing.

After updating Unity they will need to be copied into Unity again:
```
cp unity_templates/* /Applications/Unity/Unity.app/Contents/Resources/ScriptTemplates
cp unity_templates/* /mnt/c/Program\ Files/Unity/Editor/Data/Resources/ScriptTemplates
```

Quick note about the `C# Editor Script` template. When creating this template
you should initially give it the name of the Class that it is an Editor for,
once it has been created you can append the word Editor to the end of the file
name. This is so that the template can include more boilerplate code.


## Unity project files
Copy the contents of the `unity_project` or `unity_plugin_project` into your
brand new project just before you run `git init`.

### Game projects
It's rather nice to keep the examples from plugin projects but you certainly
don't want them in the build. One way of doing this is by storing the files
outside of the `Assets` directory and using symbolic links to add them.

The `mk_external.sh` and `rm_external.sh` create and delete a symbolic link to
a directory called `External` in the root of the project. Store examples and
any other files you want access to during development but don't want in your
builds. The idea is to remove the link before building and adding it again when
you need access to the files in the Unity editor.

### Plugin projects
The `export_package.sh` script is used for exporting `.unitypackage` files. It
makes a bunch of assumptions about the project structure:

* All files to be included in the package are under `Assets/RocketPants`.
* There is a file called `VERSION.txt` in the root which only contains the
version number.
* There is a directory called `UnityPackages` in the root of the project.


## About Rocket Pants
![Rocket Pants](http://rocketpants.se/logo_xsmall.png)

Rocket Pants is a small indie game studio based in Stockholm. If you like this
tool please consider supporting us by checking out our games. Find out more at
[rocketpants.se](http://rocketpants.se).
