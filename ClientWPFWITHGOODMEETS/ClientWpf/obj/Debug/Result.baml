   M S B A M L   `   `   `  ����D  @ClientWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ClientWpf	ClientWpf  5   	       ClientWpf.Result   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ClientWpf     5   	     � Title$  
SelectDate��5       � WindowStyle$
 None=�5	   	   $	��292��5
   	   $	��320��5   	   ���	#FF4A5872$	��292��5   	   $	��320��5   	   $	��292��5   	   $	��320��5   	   $��Disabled=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � $��0,0,-0.4,-6.4q�6   .+�5   
   &   System.Windows.Controls.Calendar  -   5          Name$ calendar��5      $
��Left=�6%   $��57,59,57,91q�6A    � Cursor$
 Hand��6W   ���	#FF9097B1���	#FF20D8D0$��Buxton Sketch)�6�   $��20(�6�      SelectionMode$ MultipleRange=�6�   �� 5   
   -   5         ��Name$ accept��5      $��OK��6"   $��82,259,81.4,0q�6/   $	��Top=�6F   $��37��6^   ���	#FF13CBD1
�������$$��Tw Cen MT Condensed Extra Bold)�6�   $��16(�6�   $
 Hand��6�   ��6�   Z� 6�   �� 5   
   ���	#FF9097B1$
��Left=�6%   $��47��6@   $	��Top=�6L   $	��292��6d   �� 5   
   -   5        $ MinimizeBtn��5      $��Х��6&   $��246,4,10.4,287.4q�62   $��24(�6L   $��Arial)�6�   $
 Hand��6�   $��Disabled=�6�   ��. $	��2,1q�6     ButtonStyle1#���   6q  ��6t   Z� ��6  Z�  � 	Resources 5        FocusVisual �� Property	 �� Value
 J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background 	 Button.Disabled.Border 
 Button.Disabled.Foreground �� 
TargetType �� 
TargetType ��Name ��Name��%�  &	       &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &		 �    &	
 �    &	  �    7  7  7  �� 5      .�5      ��  � ��	 5      �� 5      .R�5   "   �� $��2q�6,   
 . #��� ��6R   $��1��6�   $	 1 2R�6�   5      5       5!      �� 5"      $ 	#FFDDDDDD��6C   �� 5#      $ 	#FF707070��6?   �� 5$      $ 	#FFBEE6FD��6F   �� 5%      $ 	#FF3C7FB1��6B   �� 5&      $ 	#FFC4E5F6��6D   �� 5'      $ 	#FF2C628B��6@   �� 5(      $ 	#FFF4F4F4��6E   �� 5)      $ 	#FFADB2B5��6A   �� 5*      $ 	#FF838383��6E   �� 5+      " ��6-   .�5,      ��  �@�FocusVisualStyle8	   69   �� 5-       � ��8	  63   �� 5.       � ��8	  64   �� 5/       � ��#	 � ��63   �� 50       � ��$	 1q�68   �� 51       � ��$	 Center=�6C   �� 52       � ��$	 Center=�6A   �� 53       � ��$	 1q�60   �� 54       � ��	 55      �� 56      " ��6.   .R�57   "   �� $ border��6)   #��z��69   #��z��6e   #��z��6�   
 . ._�58   &   �� $ contentPresenter��67   |�.  #��z��6c   #��z��6�   ��. #
 z
 6�   #��z��6   59   #   5;      5=      5>      5?      ��5@      �� 5A       �� ImageSource$ Resources/min.png��6    j� Stretch$ UniformToFill=�6=   5C      �� 5D   
   $��DATES WHEN YOU CAN MEET��6   $��15,10,44.4,0q�62   $	��Top=�6H   $��32��6`   $$��Tw Cen MT Condensed Extra Bold)�6l   $��20(�6�   
�������6�   5F      5G      