# Rocket Pants Tools
A collection of scripts and tools that we made to help us in our daily work.


## Images and video for social media

### Scale a set of images for instagram video size.
```
convert -sample 640x640 sprite_**.png scaled_%02d.png
```

### Make an mp4 out of a series of png files.
```
ffmpeg -framerate 6 -i scaled_%02d.png -s:v 640x640 -c:v libx264 -profile:v high -crf 18 -pix_fmt yuv420p out.mp4
```

### Compress video using x264 and aac.
```
ffmpeg -i input.mp4 -c:v libx264 -c:a aac -strict experimental -b:a 96k out.mp4
```

### Resize multiple images without scaling them.
```
mogrify *.png -background none -gravity south -extent 20x40 *.png
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

After updating Unity they will need to be copied into this folder again:
```
/Applications/Unity/Unity.app/Contents/Resources/ScriptTemplates
```

Quick note about the `C# Editor Script` template. When creating this template
you should initially give it the name of the Class that it is an Editor for,
once it has been created you can append the word Editor to the end of the file
name. This is so that the template can include more boilerplate code.


## Screenshot
A simple script for taking screenshots at a specific resolution. Simply add the
script to a GameObject in your scene. You can take screenshots by hitting `k`
in play mode or pressing the `Take screenshot` button in the editor.

