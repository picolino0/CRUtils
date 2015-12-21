# CRUtils
A simple utility application made by [picolino0](https://www.github.com/picolino0) that does a couple of random things. This project is not really made to be used by anyone aside from the creator. Its was made (and functions are still being added to it occasionally) because there was a need for it. Who has time to search google for an application that already does that stuff, right?

## Features
 - Simulate the play/pause and next/previous buttons (in case you don't have them under your `Fn` key
 - Show a popup box when the `printscreen` button is pressed with a screenshot of all screens separately and save one of them to a adjustable folder
 - Display all screenshots in the specified screenshot folder
 - Show what track is playing on spotify when the track changes or resumes
 
## User interface
#### Main screen
![Screenshot1](http://picolino0.github.io/images/screen1.png)

This is the main screen. It'll display all images in the specified screenshot folder. On the left side you see an `Image`-icon and a `Settings`-icon. By clicking one of these you'll switch to the main and settings screen respectively

#### Screenshot preview
![Screenshot3](http://picolino0.github.io/images/screen3.png)

A preview of all screens will be shown when the `printscreen` key is pressed. Once one of the screens in the preview is clicked, a screenshot of that screen will be saved to the screenshot folder.

#### Settings screen
![Screenshot2](http://picolino0.github.io/images/screen2.png)

On the settings screen there's a couple of things you can interact with.

1. Toggle if the application will be run when windows starts
2. Toggle if the application window will be shown or immediately minimized when started
3. Toggle if the application will be minized to the tray when the `x` button is pressed
4. Toggle the simulation of the play/pause and next/previous buttons
5. Toggle if screenshots will be saved when the `printscreen` button is pressed
6. Toggle if a notification will be shown when the track changes of resumes in spotify
7. A combination of up to three buttons can be assigned to each virtual button. To change the buttons, click the textbox and press the desired button. When `Escape` is pressed, the textfield will be cleared.
8. The folder in which all screenshots will be saved. (Default is: `[pictures folder]\Screenshots`)
9. Connect to Spotify using [SpotifyAPI-Net](https://github.com/JohnnyCrazy/SpotifyAPI-NET/). This will be done automatically when the application starts.

Last updated: 20/12/2015  :shipit:
