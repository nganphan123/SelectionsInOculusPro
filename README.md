# Eye tracking in VR

Honours thesis regarding eye-tracking applications:

1. Desktop-based application with Tobii device

2. AR application on MetaQuest headset

## Demonstration

https://github.com/user-attachments/assets/d0d90ae0-9f1f-4966-8ef5-0d61deaf7c9e

## Progress

### Week 2

**Unity packages:**

https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@5.1/manual/index.html

MRTK-Unity: https://github.com/microsoft/MixedRealityToolkit-Unity
*MRTK2 eye-tracking only works on HoloLens. MRTK3 works on other devices (e.g.MetaQuest), requires more research on compatibilty of eye-tracking tool kits*

**Related  work on eye-tracking**

[Using Eyetracking to Control my Game](https://www.youtube.com/watch?v=lM8LQVDANfk)

[How To Track Eye Movement In Augmented Reality (Part 1 Face Mesh And BlendShapes)](https://www.youtube.com/watch?v=Zjdw8bHsvXc)

[Unity3d with AR Foundation - How To Setup and Implement AR Eye Tracking?](https://www.youtube.com/watch?v=kIcvAi60qlI)

[MRTK on Oculus Quest 2](https://www.youtube.com/watch?v=YLntpH_tYz4)

[Add Eye Tracking Features With Oculus Integration For Unity](https://www.youtube.com/watch?v=ZoySn7QlMfQ&t=3s)

### Week 3

[VR set up in Unity](https://developer.oculus.com/documentation/unity/unity-conf-settings/#enable-vr-support)

[Oculus Integration SDK](https://developer.oculus.com/documentation/unity/unity-import/#import-sdk-from-unity-asset-store)

[Oculus XR plugin](https://developer.oculus.com/documentation/unity/unity-xr-plugin/)

Task: Follow [the video](https://www.youtube.com/watch?v=ZoySn7QlMfQ&t=3s) and code the app

[Source code](https://github.com/nganphan123/SimpleEyeTracking) 

### Week 4

Cast VR screen to PC using SideQuest [download link](https://sidequestvr.com/download)

Look into decreasing the inconsistent movement of the rays by not moving the ray when eye gaze change is minimal

Turn the ray into dot for better selection

### Week 5

https://github.com/nganphan123/COSC-449/assets/58235340/81fcf745-e827-418c-9552-356e76413190

Oculus eye-gaze api doesn't work well with side eye-gaze. To decrease the offset between the ray and the object, user needs to face directly to the object.

### Week 6

Read abstraction from research paper

|Title                                                                                                          |DOI                            |Keywords                                                                                                    |Source                                                           |
|---------------------------------------------------------------------------------------------------------------|-------------------------------|--------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------|
|Prospective on Eye-Tracking-based Studies in Immersive Virtual Reality                                         |10.1109/CSCWD49262.2021.9437692|tracking gaze points to manipulate the VR environment                                                   |https://ieeexplore.ieee.org/abstract/document/9437692            |
|A comparative study of eye tracking and hand controller for aiming tasks in virtual reality                    |10.1145/3317956.3318153        |gaze aiming compared to controller in "aim and shoot" task; qualitative data was gathered               |https://dl.acm.org/doi/abs/10.1145/3317956.3318153               |
|A Fitt's Law Study of Gaze-Hand Alignment for Selection in 3D User Interfaces                                |10.1145/3544548.3581423        |gaze for target pre-selection; Gaze&Finger and Gaze&Handray techniques                                  |https://dl.acm.org/doi/abs/10.1145/3544548.3581423               |
|Comparison of Eye-Based and Controller-Based Selection in Virtual Reality                                      |10.1080/10447318.2020.1826190  |Fitt's modeling of the eye-based selection                                                            |https://www.tandfonline.com/doi/abs/10.1080/10447318.2020.1826190|
|Pinch, Click, or Dwell: Comparing Different Selection Techniques for Eye-Gaze-Based Pointing in Virtual Reality|10.1145/3448018.3457998        |subjects pointed with (eye-)gaze; selected / activated the targets by pinch, clicking a button, or dwell|https://dl.acm.org/doi/abs/10.1145/3448018.3457998               |
|Evaluating ray casting and two gaze-based pointing techniques for object selection in virtual reality          |10.1145/3281505.3283382        |interaction techniques: ray casting, dwell time and gaze trigger in a simple object selection task      |https://dl.acm.org/doi/abs/10.1145/3281505.3283382               |
|Eye&Head: Synergetic Eye and Head Movement for Gaze Pointing and Selection                                     |10.1145/3332165.3347921        |                                                                                                        |https://dl.acm.org/doi/abs/10.1145/3332165.3347921               |
|EyePointing: A Gaze-Based Selection Technique                                     |10.1145/3317956.3318153        |technique which combines the MAGIC pointing technique and the referential mid-air pointing gesture to selecting objects in a distance                                                        |https://dl.acm.org/doi/abs/10.1145/3317956.3318153               |

[Similar eye gaze project](https://github.com/fabio914/EyeTrackingKeyboard/blob/main/EyeTrackingKeyboard/Assets/Scripts/EyeTrackingKeyboard.cs)

### Week 7

#### Find research paper related to eye tracking vs. menu layouts

[Excel sheet](https://docs.google.com/spreadsheets/d/1ShairuokofrCZYIZ3f2G1wFQyLslPylr9cxbPQC4i5g/edit#gid=0)
[Details doc](https://docs.google.com/document/d/1DVHEEtrXHDCSYFMimdGvQCsItm2M0SevcQ_52cCu9TM/edit#heading=h.vbhfo8ugiwqo)

### Week 8 (reading break)

### Week 9 - 10

1. Fine tune eye tracking app

2. Come up with research ideas. [Link](https://docs.google.com/document/d/1I9NhRJ1p1BYQKidVRXgE4vP2rpZKVB_9knp0B-ZxDgY/edit?usp=sharing)

### Week 11

Develop test application that controls moving objects with controllers

https://github.com/nganphan123/COSC-449/assets/58235340/a2160589-2623-4cd0-9666-352dc36de444

Develop test application that controls moving objects with eye gazing and hand pinching

#### Demonstration

https://github.com/nganphan123/COSC-449/assets/58235340/d1da30a9-1aba-41c5-b0a8-df484f848f96

### Week 12 (December 21, 2023)

Migrated application to a new repository for advanced functionalities

[New repository](https://github.com/nganphan123/SelectionsInOculusPro)

New features completed:
- Implemented ray casting from head: when the user moves their head, the ray starting from their head produces a list of objects that the ray collides with
- Integrated with the existent eye gaze ray casting

#### Demonstration

Video description: the upper ray (has yellow colour) is the head control. The lower rays (has purple colour) are the eye control. Both ray types turn red when they hit an object.

https://github.com/nganphan123/COSC-449/assets/58235340/ec1d6f9d-be75-4932-9024-b284ca5c90b0

### Week 13 - 17 

Winter break

### Week 18 (February 1, 2024)

- Implement UI canvas for configuration options:
  - Technique:
    - Eye raycasting
    - Head raycasting
    - Head + Eye raycasting
    - Hand controllers
  - Object speed: 5, 10, 15
  - Object size: 10x10, 20x20, 25x25
  - Number of selection times: 5, 10, 15
- Configured game based on user options

### Week 19 (February 8, 2024)

- Researched how to use facial expression and eye blinking to make selections (besides hand pinching)

[Oculus SDK](https://developer.oculus.com/documentation/unity/move-face-tracking/#face-blendshapes)

#### Demonstration
1. Select object with right eye blinking
   
https://github.com/nganphan123/COSC-449/assets/58235340/d3f63a7f-9ec1-4e29-89e1-f22dbe0f0838

2. Select object with hand pinching 

https://github.com/nganphan123/COSC-449/assets/58235340/c37472f3-d04c-4584-95be-9861d1fb6772

### Week 20 (March 28, 2024)

- Add head range selection: objects within the range of head direction will slow down.

https://github.com/nganphan123/COSC-449/assets/58235340/ba2dd14a-3009-454b-bfaa-4cdcd3bf45ec

- Connect to firebase
  
![Screenshot 2024-03-28 181354](https://github.com/nganphan123/COSC-449/assets/58235340/56e52b2d-ab36-4e33-9195-244b238c5e96)

