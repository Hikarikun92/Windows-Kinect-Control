Copyright © 2014  Lucas José dos Santos Souza

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

Windows Kinect Control
======
This program implements a Microsoft Kinect For Windows application that can be used to control the mouse cursor based on the user's hands.

It requires a Microsoft Kinect for Windows device (NOT the 2nd generation one) and its SDK version 1.7, available at <http://www.microsoft.com/en-us/download/details.aspx?id=36996>. It might also work with an Xbox 360 Kinect, but it was not tested.

The program was built using Microsoft Visual Studio 2012 Ultimate in a Windows 7 machine, but should run with any configuration that supports .NET Framework 4.5, as all the needed files are included in this project.

It's runs as a background task which, whithin a specified rate (default 15 frames/sec), looks for a user's "main hand" (default right hand) position, moving the mouse cursor accordingly across the screen. There is a notify icon on the system tray that notifies when the sensor is ready. By default, the cursor will only be updated if the "next position" is located 20 pixels far from the last one, in the x or y axis. This can be disabled in the Options window ("Opções"), by unchecking the Precision mode checkbox ("Modo de precisão").

Also, it checks for the "secondary hand's" (default left hand) position in a 3-dimensional space, checking for its depth accordint to its corresponding shoulder's depth. This is used to send mouse clicks with the 3 buttons according to the secondary hand's height according to its shoulder.

If the secondary hand is located over 20 cm above the secondary shoulder and 30 cm in front of it, the program sends an event indicating a mouse click with the right button. If the hand is located less than 20 cm above, less than 10 cm under the shoulder and 45 cm in front of it, the program sends a middle-button click. Otherwise, if the hand is located more than 10 cm under the shoulder and 45 cm in front of it, a left-button click is sent.

The program also counts with an Options ("Opções") window, a Camera window showing what the sensor is "seeing" and a virtual keyboard (Free Virtual Keyboard <http://freevirtualkeyboard.com/>). Windows' default virtual keyboard, for some reason, does not work, making the Kinect streams stop and the program freeze. These features are all available through the notify icon's menu. The fourth option closes the program and releases its resources.
