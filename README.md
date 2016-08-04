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


## Google Play translations
If you don't provide translations for the app description on Google Play it
will use Google Translate in non English markets. That is usually not a good
solution. One solution is to populate all translations with the English texts.

The code in `google-translations.js` automates this.


## Unity script templates for C#
The C# templates are mostly to save some time when creating new script files.
At the moment the built in ones use tabs and some strange spacing rules, our
code style dictates 4 spaces and civilized spacing.

After updating Unity they will need to be copied into this folder again:
```
/Applications/Unity/Unity.app/Contents/Resources/ScriptTemplates
```
