Hi there!

0. Install Unity Version 2019.2.19f1 // Android Studio and atleast your devices apk (android 8+)
    - didnt check the requiered android sdk for the open cv lib, maybe we can reduce the required vers

1. File / Build Settings
    Choose Android and press "Build" - this will create an .apk which can be stored on an android device
    Make sure to connect your device (with developer mode unlocked) before pressign "Build And Run" - it will directly load the .apk to your device and run the app

2. Edit / Preferences
    Deselect "Android SDK Tools Installed with Unity" - Insert your own path to your android SDK installed by Android Studio (usually Useres/Username/AppData/Local/Android/SDK)
    Check if you can already build the app  to you device without compiling errors, if not, you probaly got to set the path to your JDK aswell

3. Check out Examples
    Assets/ OpenCVwithUnity/ Demo
    Check out the Demo Scene in your Editor. They use unsafe code but that shouldnt be an issue.
    
Also created a simple Camera Controller in a sample scene, you should be able to use ur devices camera. Currently the scaling is bit off, Unitys Webcamtexture is quiet annoying but guess we'll fix that soon ;)
