# UnityArabic
Localizing Arabic language in Unity3D . Using the Arabic Support plugin and localization tools demo.
This is a sample used to showcase how to localize Arabic Langauge using the Arabic Support plugin.
The localization tools is built on the offical Unity Learning tutorial.

Check out the Arabic support plugin created by Abdullah Konash : https://github.com/Konash/arabic-support-unity
How it works?

Step 1:
Assets\StreamingAssets

Stores the translation of the selected langauge in  a JSON file.


Step 2:
A button passes the relavent langauge file (e.i localizedText_ar.json) to a function from the LocaliztionManger Object

Step3:
The LocaliztionManger Object trys to find the name of the file along (and the key value pairs in it) , then displays the text if it found.Otherwise it will inform the developer that the text was not found.

Step4:
Once the text has been found, move on to the next scene . The data in the selected JSON file has been predetermind  at this point.


Many thanks to Abdullah Konash and the Unity Learning Team.
