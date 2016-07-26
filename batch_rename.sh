for file in *.tmx; do
    mv "$file" "`basename $file .tmx`.xml"
done
