   M S B A M L   `   `   `  ����D  @ClientWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ClientWpf	ClientWpf  5   	       ClientWpf.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ClientWpf     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ 
MainWindow��5	   	   $	��700��6   $	��640��6)   $	��640��65   $	��700��6D   $	��640��6T   $	��700��6c    � 
ResizeMode$ NoResize=�6s    � WindowStyle$
 None=�6�    � ShowInTaskbar .  � SizeToContent$ Width=�6�    � 	Resources 5
         FocusVisual �� Property �� Value	 J� SnapsToDevicePixels
 �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1 �� 
TargetType �� 
TargetType ��Name ��Name � Cursor �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7 	 �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   	 . #��� ��6J   $��1��6�   $	
 1 2R�6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6%   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5        � ��8  6,   �� 5!       � ��# � ��6+   �� 5"       � ��$ 1q�60   �� 5#       � ��$ Center=�6;   �� 5$       � ��$ Center=�69   �� 5%       � ��$ 1q�6(   �� 5&       � �� 5'      �� 5(      " ��6&   .R�5)      �� $ border��6!   #��z��61   #��z��6]   #��z��6�   	 . ._�5*      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. #	 z	 6�   #��z��6  $
 Hand��6W  5+       5,      P� 5-       �@��IsDefaulted . . �5.   "   �� $ border��6@   # � ��6T    � ��5/      P� 51       � �� . . �52   "   �� $ border��6?   8   � ��6S   �� 53   "   $ border��6@   8   � ��6T   54      P� 55       � {� .  . �56   "   �� $ border��6?   8   � ��6S   �� 57   "   $ border��6@   8   � ��6T   �� 58   "   $ contentPresenter��6K   8   � ��6i   59      5;      5=      5>      5?      .��5A      � ���	#FF4A5872 J� IsHitTestVisible . $ Arrow��6:    � UseLayoutRounding . .+�5C   
   �� ���	#FF2A3142$
��Left=�6%   $	��699��6@   $	��Top=�6M   $	��175��6e   $��-1,1,0,0q�6q   �� 5D   
   -   5         ��Name$ changeLb��5D      $��GLOBAL CHAT��6"   $
��Left=�68   $��
351,75,0,0q�6S   $	��Top=�6g   $$��Tw Cen MT Condensed Extra Bold)�6   $��20(�6�   $
��Bold"�6�   ���	#FF13CBD1���	#FF121A2B$��21��6�   $	��5,1q�6  �� 5E   
   -   5         ��Name$ SendBtn��5E      $��Отправить��6"   $
��Left=�66   $��569,642,0,0q�6Q   $	��Top=�6f   $��42��6~   $��42��6�   $��Arial)�6�   $��14(�6�   $
��Bold"�6�   $
 Hand��6�   #��� 
 6Y  ��6�   Z� ��6  Z�  5F      ��%�  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  �� 5G      .�5H      ��  � �� 5I      �� 5J      .R�5K   "   �� $��2q�6,   	 . #��� ��6R   $��1��6�   $	
 1 2R�6�   5L      5N      5O      �� 5P      $ 	#FFDDDDDD��6C   �� 5Q      $ 	#FF707070��6?   �� 5R      $ 	#FFBEE6FD��6F   �� 5S      $ 	#FF3C7FB1��6B   �� 5T      $ 	#FFC4E5F6��6D   �� 5U      $ 	#FF2C628B��6@   �� 5V      $ 	#FFF4F4F4��6E   �� 5W      $ 	#FFADB2B5��6A   �� 5X      $ 	#FF838383��6E   �� 5Y      " ��6-   .�5Z      ��  �@�FocusVisualStyle8   69   �� 5[       � ��8  63   �� 5\       � ��8  64   �� 5]       � ��# � ��63   �� 5^       � ��$ 1q�68   �� 5_       � ��$ Center=�6C   �� 5`       � ��$ Center=�6A   �� 5a       � ��$ 1q�60   �� 5b       � �� 5c      �� 5d      " ��6.   .R�5e   "   �� $ border��6)   #��z��69   #��z��6e   #��z��6�   	 . ._�5f   &   �� $ contentPresenter��67   |�.  #��z��6c   #��z��6�   ��. #	 z	 6�   #��z��6   5g   #   5i      5k      5l      5m      ��5n      �� 5o       �� ImageSource$ Resources/send.png��6    j� Stretch$ UniformToFill=�6>   5q      �� 5r   
   -   5         ��Name$ OurMessageBox��5r      $
��Left=�6C   $��52��6^    �� TextWrapping$
 Wrap=�6j   $	��Top=�6~   $	��276��6�   $��251,637,0,0q�6�   ��. $��Comic Sans MS)�6�   $��16(�6�   ���	#FF212D47 �� SelectionBrush �	#FF04D1FF4  .System.Windows.Automation.AutomationProperties   IsColumnHeader . $	 Pen��6y  ���	#FFDBDEEA J� OpacityMask �	#FF13CBD1��6  Z� 6�  �� 5s   
   $
��Left=�6   $��70��6/   $��-1,0,0,0q�6;   $	��Top=�6M   $	��641��6e   	 . ���	#FF9097B16�   �� 5t   
   -   5        $ closeBtn��5t      $��Х��6#   $
��Left=�6/   $��
581,15,0,0q�6J   $	��Top=�6^   $��36��6v   $��35��6�   $��24(�6�   $��Arial)�6�   $
 Hand��6�   $��Disabled=�6�   ��. $	��2,1q�6B  #��� 
 6�  ��6�   Z� ��6P  Z�  5u      ��%�  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  �� 5v      .�5w      ��  � �� 5x      �� 5y      .R�5z   "   �� $��2q�6,   	 . #��� ��6R   $��1��6�   $	
 1 2R�6�   5{      5}      5~      �� 5      $ 	#FFDDDDDD��6C   �� 5�      $ 	#FF707070��6?   �� 5�      $ 	#FFBEE6FD��6F   �� 5�      $ 	#FF3C7FB1��6B   �� 5�      $ 	#FFC4E5F6��6D   �� 5�      $ 	#FF2C628B��6@   �� 5�      $ 	#FFF4F4F4��6E   �� 5�      $ 	#FFADB2B5��6A   �� 5�      $ 	#FF838383��6E   �� 5�      " ��6-   .�5�      ��  �@�FocusVisualStyle8   69   �� 5�       � ��8  63   �� 5�       � ��8  64   �� 5�       � ��# � ��63   �� 5�       � ��$ 1q�68   �� 5�       � ��$ Center=�6C   �� 5�       � ��$ Center=�6A   �� 5�       � ��$ 1q�60   �� 5�       � �� 5�      �� 5�      " ��6.   .R�5�   "   �� $ border��6)   #��z��69   #��z��6e   #��z��6�   	 . ._�5�   &   �� $ contentPresenter��67   |�.  #��z��6c   #��z��6�   ��. #	 z	 6�   #��z��6   5�   #   5�      5�      5�      5�      ��5�      �� 5�      $ Resources/close1.png��6   $ UniformToFill=�6@   5�      �� 5�   
   $
��Left=�6   $��94��6/   $��
-8,-13,0,0q�6;   $	��Top=�6O   $��95��6g    .    �� RadiusX$  45��6�   ! �� RadiusY$! 34��6�   " J� RenderTransformOrigin$" 0.5,0.5&�6�   ��5�      �� 5�      $  Resources/YesLetsMeet2.png��6   $ Uniform=�6F   # �� RelativeTransform# 5�      V� 5�      .~�5�      �� $ �� CenterY$	$ 0.5Q�6-   % �� CenterX$	% 0.5Q�6;   & �� ScaleY$& 1Q�6I   ' �� ScaleX$' 1Q�6T   �� 5�      ( �� AngleY$( 0Q�6,   ) �� AngleX$) 0Q�67   * �� CenterY$	* 0.5Q�6B   + �� CenterX$	+ 0.5Q�6P   �� 5�      , �� Angle$, 0Q�6.   - �� CenterY$	- 0.5Q�68   . �� CenterX$	. 0.5Q�6F   T� 5�      5�      5�      5�      �� 5�   
   -   5        / ��Name$/ ChatBox��5�      $
��Left=�6'   $	��536��6B   $��
202,96,0,0q�6O   $	��Top=�6c   $	��400��6{   0 �� 
IsReadOnly0 . ���	#FF121A2B���	#FF121A2B �	#FF04D1FF���	#FFABAFC3$ Arrow��6  $��Comic Sans MS)�6+  . �5�      /� .T�5�      J� 1 �� Margin$1 2q�6   .*�6'   .*�5�      �� �6   �� *Text+5�      5�      5�      �� 5�   
   -   5        2 ��Name$2 USERSBOX��5�      $
��Left=�6%   $��
15,144,0,0q�6@   $	��Top=�6T   $	��141��6l   $��30��6x   ���	#FFABAFC3���	#FF212D47$
 Hand��6�   $$��Tw Cen MT Condensed Extra Bold)�6�   $��16(�6�   ��5�      �� 5�      " ��6   .�5�      ��  � �� �	#FF151E3263   5�      5�      �� 5�   
   -   5        3 ��Name$	3 Rec��5�      ���	#FF212D47$
��Left=�62   $��59��6M   $��434,580,0,0q�6Y   ���	#FF04D1FF$	��Top=�6�   $	��135��6�   4 J� Opacity$4 0Q�6�   �� 5�   
   -   5        $ b1��5�      $��:)��6   $
��Left=�6*   $��442,585,0,0q�6E   $	��Top=�6Z   $��20��6r   
�������$4 0Q�6�   ��6�   Z� ��6�   Z� 6�   �� 5�   
   -	   5        $ b2��5�      $��:(��6   $
��Left=�6*   $��464,585,0,0q�6E   $	��Top=�6Z   $��23��6r   
�������$4 0Q�6�   ��6�   Z� ��6�   Z� 6�   �� 5�   
   -
   5        $ b3��5�      $	��>:)��6   $
��Left=�6.   $��490,585,0,0q�6I   $	��Top=�6^   $��22��6v   
�������$4 0Q�6�   ��6�   Z� ��6�   Z� 6�   �� 5�   
   -   5        $ b4��5�      $	��>:(��6   $
��Left=�6.   $��512,585,0,0q�6I   $	��Top=�6^   $��25��6v   
�������$4 0Q�6�   ��6�   Z� ��6�   Z� 6�   �� 5�   
   -   5        $ b5��5�      $��:O��6   $
��Left=�6*   $��542,585,0,0q�6E   $	��Top=�6Z   $��20��6r   
�������$4 0Q�6�   ��6�   Z� ��6�   Z� 6�   �� 5�   
   -   5        $ b6��5�      $��:$��6   $
��Left=�6*   $��442,612,0,0q�6E   $	��Top=�6Z   $��20��6r   
�������$4 0Q�6�   ��6�   Z� ��6�   Z� 6�   �� 5�   
   -   5        $ b7��5�      $��8)��6   $
��Left=�6*   $��467,612,0,0q�6E   $	��Top=�6Z   $��20��6r   
�������$4 0Q�6�   ��6�   Z� ��6�   Z� 6�   �� 5�   
   -   5        $ b8��5�      $��;)��6   $
��Left=�6*   $��492,612,0,0q�6E   $	��Top=�6Z   $��20��6r   
�������$4 0Q�6�   ��6�   Z� ��6�   Z� 6�   �� 5�   
   -   5        $ b9��5�      $��:3��6   $
��Left=�6*   $��517,612,0,0q�6E   $	��Top=�6Z   $��20��6r   
�������$4 0Q�6�   ��6�   Z� ��6�   Z� 6�   �� 5�   
   -   5        $	 b10��5�      $��:*��6   $
��Left=�6+   $��542,612,0,0q�6F   $	��Top=�6[   $��20��6s   
�������$4 0Q�6�   ��6�   Z� ��6�   Z� 6�   �� 5�   
   -   5        $ Smiles��5�      $��:)��6!   $
��Left=�6.   $��527,642,0,0q�6I   $	��Top=�6^   $��42��6v   $��42��6�   $��1,1,1,2q�6�   $
 Hand��6�   #��� 
 6/  ��6�   Z� ��6�   Z�  5�      ��%�  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  �� 5�      .�5�      ��  � �� 5�      �� 5�      .R�5�   "   �� $��2q�6,   	 . #��� ��6R   $��1��6�   $	
 1 2R�6�   5�      5�      5�      �� 5�      $ 	#FFDDDDDD��6C   �� 5�      $ 	#FF707070��6?   �� 5�      $ 	#FFBEE6FD��6F   �� 5�      $ 	#FF3C7FB1��6B   �� 5�      $ 	#FFC4E5F6��6D   �� 5�      $ 	#FF2C628B��6@   �� 5�      $ 	#FFF4F4F4��6E   �� 5�      $ 	#FFADB2B5��6A   �� 5�      $ 	#FF838383��6E   �� 5�      " ��6-   .�5�      ��  �@�FocusVisualStyle8   69   �� 5�       � ��8  63   �� 5�       � ��8  64   �� 5�       � ��# � ��63   �� 5�       � ��$ 1q�68   �� 5�       � ��$ Center=�6C   �� 5�       � ��$ Center=�6A   �� 5�       � ��$ 1q�60   �� 5�       � �� 5�      �� 5�      " ��6.   .R�5�   "   �� $ border��6)   #��z��69   #��z��6e   #��z��6�   	 . ._�5�   &   �� $ contentPresenter��67   |�.  #��z��6c   #��z��6�   ��. #	 z	 6�   #��z��6   5�   #   5�      5�      5�      5�      ��5�      �� 5�      $ Resources/smile.png��6   $ UniformToFill=�6?   5�      �� 5�   
   $��ACTIVE USERS��6   $
��Left=�6'   $��
10,119,0,0q�6B   $	��Top=�6V   ���	#FFABAFC3$$��Tw Cen MT Condensed Extra Bold)�6�   $��14(�6�   �� 5�   
   $��YES, LET'S MEET!��6   $
��Left=�6+   $��	157,5,0,0q�6F   $	��Top=�6Y   $��65��6q   $	��319��6}   
�������$$��Tw Cen MT Condensed Extra Bold)�6�   $��48(�6�   �� 5�   
   -   5        5 ��Name$	5 Nik��5�      $
��Left=�6!   $��	15,93,0,0q�6<   $
��Wrap=�6O   $	��Top=�6c   $��26��6{   $��95��6�   $��Impact)�6�   $��18(�6�   ���	#FF13CBD1��6�   Z� �� 5�   
   $��NICKNAME��6   $
��Left=�6#   $��	10,70,0,0q�6>   $	��Top=�6Q   $$��Tw Cen MT Condensed Extra Bold)�6i   $��14(�6�   $
��Bold"�6�   ���	#FFABAFC36�   �� 5�   
   -   5        $ SendFile��5�      $
��File��6#   $
��Left=�62   $��206,642,0,0q�6M   $	��Top=�6b   $��42��6z   $��42��6�   $
 Hand��6�   #��� 
 6%  ��6�   Z� ��6�   Z�  5�      ��%�  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  �� 5�      .�5�      ��  � �� 5�      �� 5�      .R�5�   "   �� $��2q�6,   	 . #��� ��6R   $��1��6�   $	
 1 2R�6�   5      5     5     �� 5     $ 	#FFDDDDDD��6C   �� 5     $ 	#FF707070��6?   �� 5     $ 	#FFBEE6FD��6F   �� 5     $ 	#FF3C7FB1��6B   �� 5     $ 	#FFC4E5F6��6D   �� 5	     $ 	#FF2C628B��6@   �� 5
     $ 	#FFF4F4F4��6E   �� 5     $ 	#FFADB2B5��6A   �� 5     $ 	#FF838383��6E   �� 5     " ��6-   .�5     ��  �@�FocusVisualStyle8   69   �� 5      � ��8  63   �� 5      � ��8  64   �� 5      � ��# � ��63   �� 5      � ��$ 1q�68   �� 5      � ��$ Center=�6C   �� 5      � ��$ Center=�6A   �� 5      � ��$ 1q�60   �� 5      � �� 5     �� 5     " ��6.   .R�5  "   �� $ border��6)   #��z��69   #��z��6e   #��z��6�   	 . ._�5  &   �� $ contentPresenter��67   |�.  #��z��6c   #��z��6�   ��. #	 z	 6�   #��z��6   5  #   5     5     5      5!     ��5"     �� 5#     $ UniformToFill=�6   $ Resources/file.png��65   5%     �� 5&  
   $
��Left=�6   $��674,-146,-154,0q�6.   $	��Top=�6G   $	��120��6_   �� 5'  
   -   5        $ MinimizeBtn��5'     $��Х��6&   $
��Left=�62   $��
545,15,0,0q�6M   $	��Top=�6a   $��36��6y   $��35��6�   $��24(�6�   $��Arial)�6�   $
 Hand��6�   $��Disabled=�6�   ��. $	��2,1q�6H  #��� 
 6�  ��6�   Z� ��6V  Z�  5(     ��%�  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  �� 5)     .�5*     ��  � �� 5+     �� 5,     .R�5-  "   �� $��2q�6,   	 . #��� ��6R   $��1��6�   $	
 1 2R�6�   5.     50     51     �� 52     $ 	#FFDDDDDD��6C   �� 53     $ 	#FF707070��6?   �� 54     $ 	#FFBEE6FD��6F   �� 55     $ 	#FF3C7FB1��6B   �� 56     $ 	#FFC4E5F6��6D   �� 57     $ 	#FF2C628B��6@   �� 58     $ 	#FFF4F4F4��6E   �� 59     $ 	#FFADB2B5��6A   �� 5:     $ 	#FF838383��6E   �� 5;     " ��6-   .�5<     ��  �@�FocusVisualStyle8   69   �� 5=      � ��8  63   �� 5>      � ��8  64   �� 5?      � ��# � ��63   �� 5@      � ��$ 1q�68   �� 5A      � ��$ Center=�6C   �� 5B      � ��$ Center=�6A   �� 5C      � ��$ 1q�60   �� 5D      � �� 5E     �� 5F     " ��6.   .R�5G  "   �� $ border��6)   #��z��69   #��z��6e   #��z��6�   	 . ._�5H  &   �� $ contentPresenter��67   |�.  #��z��6c   #��z��6�   ��. #	 z	 6�   #��z��6   5I  #   5K     5M     5N     5O     ��5P     �� 5Q     $ Resources/min.png��6   $ UniformToFill=�6=   5S     �� 5T  
   -   5        $ 
privateBtn��5T     $��PRIVATE MESSAGE��6%   $
��Left=�6?   $��
18,188,0,0q�6Z   $	��Top=�6n   $	��138��6�   $��36��6�   ���	#FFFCFCFB���	#FF13CBD1$$��Tw Cen MT Condensed Extra Bold)�6�   $��16(�6  #��� 
 64  ��6�   Z� 64  �� 5U  
   -   5        $ 	globalBtn��5U     $��CHAT MESSAGE��6$   $
��Left=�6;   $��
18,229,0,0q�6V   $	��Top=�6j   $	��138��6�   $��36��6�   ���	#FFFCFCFB���	#FF13CBD1$$��Tw Cen MT Condensed Extra Bold)�6�   $��16(�6    ButtonStyle2#���  60  $
 Hand��6W  ��6�   Z�  5V     ��%R  &	       7   7  7  7  7  7  7  7 	 �� 5W     " ��6-   .�5X     ��  �@�FocusVisualStyle8   69   �� 5Y      � ��8  63   �� 5Z      � ��8  64   �� 5[      � ��# � ��63   �� 5\      � ��$ 1q�68   �� 5]      � ��$ Center=�6C   �� 5^      � ��$ Center=�6A   �� 5_      � ��$ 1q�60   �� 5`      � �� 5a     �� 5b     " ��6.   .R�5c  "   �� $ border��6)   #��z��69   #��z��6e   #��z��6�   	 . ._�5d  &   �� $ contentPresenter��67   |�.  #��z��6c   #��z��6�   ��. #	 z	 6�   #��z��6   5e  #    5f  "   P� 5g  &    �@��IsDefaulted . . �5h  *   �� $ border��6H   # � ��6\    � ��5i  '   P� 5k  &    � �� . . �5l  *   �� $ border��6G   8   � ��6[   �� 5m  *   $ border��6H   8   � ��6\   5n  '   P� 5o  &    � {� .  . �5p  *   �� $ border��6G   8   � ��6[   �� 5q  *   $ border��6H   8   � ��6\   �� 5r  *   $ contentPresenter��6S   8   � ��6q   5s  '   5u     5w     5x     5y     5z     �� 5{  
   -   5        $
 meet��5{     $
��MEET��6   $
��Left=�6.   $��
18,270,0,0q�6I   $	��Top=�6]   $	��138��6u   $��36��6�   ���	#FFFCFCFB���	#FF13CBD1$$��Tw Cen MT Condensed Extra Bold)�6�   $��16(�6�   #���  6  $
 Hand��6@  ��6�   Z�  5|     ��%R  &	       7   7  7  7  7  7  7  7 	 �� 5}     " ��6-   .�5~     ��  �@�FocusVisualStyle8   69   �� 5      � ��8  63   �� 5�      � ��8  64   �� 5�      � ��# � ��63   �� 5�      � ��$ 1q�68   �� 5�      � ��$ Center=�6C   �� 5�      � ��$ Center=�6A   �� 5�      � ��$ 1q�60   �� 5�      � �� 5�     �� 5�     " ��6.   .R�5�  "   �� $ border��6)   #��z��69   #��z��6e   #��z��6�   	 . ._�5�  &   �� $ contentPresenter��67   |�.  #��z��6c   #��z��6�   ��. #	 z	 6�   #��z��6   5�  #    5�  "   P� 5�  &    �@��IsDefaulted . . �5�  *   �� $ border��6H   # � ��6\    � ��5�  '   P� 5�  &    � �� . . �5�  *   �� $ border��6G   8   � ��6[   �� 5�  *   $ border��6H   8   � ��6\   5�  '   P� 5�  &    � {� .  . �5�  *   �� $ border��6G   8   � ��6[   �� 5�  *   $ border��6H   8   � ��6\   �� 5�  *   $ contentPresenter��6S   8   � ��6q   5�  '   5�     5�     5�     5�     5�     �� 5�  
   -   5        $ Confirm��5�     $��CONFIRM RESULT��6"   $
��Left=�6;   $��
18,311,0,0q�6V   $	��Top=�6j   $	��138��6�   $��36��6�   ���	#FFFCFCFB���	#FF13CBD1$$��Tw Cen MT Condensed Extra Bold)�6�   $��16(�6  #���  6/  $
 Hand��6V  ��6�   Z�  5�     ��%R  &	       7   7  7  7  7  7  7  7 	 �� 5�     " ��6-   .�5�     ��  �@�FocusVisualStyle8   69   �� 5�      � ��8  63   �� 5�      � ��8  64   �� 5�      � ��# � ��63   �� 5�      � ��$ 1q�68   �� 5�      � ��$ Center=�6C   �� 5�      � ��$ Center=�6A   �� 5�      � ��$ 1q�60   �� 5�      � �� 5�     �� 5�     " ��6.   .R�5�  "   �� $ border��6)   #��z��69   #��z��6e   #��z��6�   	 . ._�5�  &   �� $ contentPresenter��67   |�.  #��z��6c   #��z��6�   ��. #	 z	 6�   #��z��6   5�  #    5�  "   P� 5�  &    �@��IsDefaulted . . �5�  *   �� $ border��6H   # � ��6\    � ��5�  '   P� 5�  &    � �� . . �5�  *   �� $ border��6G   8   � ��6[   �� 5�  *   $ border��6H   8   � ��6\   5�  '   P� 5�  &    � {� .  . �5�  *   �� $ border��6G   8   � ��6[   �� 5�  *   $ border��6H   8   � ��6\   �� 5�  *   $ contentPresenter��6S   8   � ��6q   5�  '   5�     5�     5�     5�     5�     5�     5�     