   M S B A M L   `   `   `  ����D  @ClientWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ClientWpf	ClientWpf  5   	       ClientWpf.SelectDate   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:ClientWpf     5   	     � Title$  
SelectDate��5   	    � WindowStyle$
 None=�5	   	   $	��292��5
   	   $	��320��5   	   ���	#FF4A5872$	��292��5   	   $	��320��5   	   $	��292��5   	   $	��320��5   	   $��Disabled=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � .+�5   
   &   System.Windows.Controls.Calendar  -   5          Name$
 cale��5      $��57,59,57,91q�6!    � Cursor$
 Hand��6b   ���	#FF9097B1���	#FF20D8D0$��Buxton Sketch)�6�   $��20(�6�   �� 5   
   -   5         ��Name$ button��5      $��ENTER DATES��6!   $��82,226,82,0q�67   $	��Top=�6L   $��37��6d   ���	#FF13CBD1
�������$$��Tw Cen MT Condensed Extra Bold)�6�   $��16(�6�   $
 Hand��6   ��6�   Z� 6   �� 5   
   -   5        $ button1��5      $��CANCEL��6"   $��82,265,82,0q�63   $	��Top=�6H   $��37��6`   ���	#FF13CBD1
�������$$��Tw Cen MT Condensed Extra Bold)�6�   $��16(�6�   $
 Hand��6�   ��6�   Z� 6�   �� 5   
   ���	#FF9097B1$
��Left=�6%   $��47��6@   $	��Top=�6L   $	��292��6d   �� 5   
   -   5        $ closeBtn��5      $�� ��6#   $��255,10,10,0q�6.   $	��Top=�6C   $��27��6[   $��24(�6g   $��Arial)�6�   $
 Hand��6�   $��Disabled=�6�   ��. $	��2,1q�6     ButtonStyle1#���   6�  ��6�   Z� ��6(  Z�  � 	Resources 5        FocusVisual �� Property �� Value	 J� SnapsToDevicePixels
 �� StrokeDashArray % !Calendar.SelectedDates.Background �� Color  Button.Static.Background  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border 	 Button.Disabled.Background 
 Button.Disabled.Border  Button.Disabled.Foreground �� 
TargetType �� 
TargetType ��Name ��Name��%�  &	       &	 �     &	 �     &	 �     &	     &	 1    &	 T    &	 w    &		 �    &	
 �    &	 �    &	      7  7  7  �� 5      .�5      ��  � �� 5      �� 5      .R�5   "   �� $��2q�6,   	 . #��� ��6R   $��1��6�   $	
 1 2R�6�   5       5"      5#      �� 5$      $
 Blue��6L   �� 5%      $ 	#FFDDDDDD��6C   �� 5&      $ 	#FF707070��6?   �� 5'      $ 	#FFBEE6FD��6F   �� 5(      $ 	#FF3C7FB1��6B   �� 5)      $ 	#FFC4E5F6��6D   �� 5*      $ 	#FF2C628B��6@   �� 5+      $ 	#FFF4F4F4��6E   �� 5,      $ 	#FFADB2B5��6A   �� 5-      $ 	#FF838383��6E   �� 5.      " ��6-   .�5/      ��  �@�FocusVisualStyle8   69   �� 50       � ��8  63   �� 51       � ��8  64   �� 52       � ��# � ��63   �� 53       � ��$ 1q�68   �� 54       � ��$ Center=�6C   �� 55       � ��$ Center=�6A   �� 56       � ��$ 1q�60   �� 57       � �� 58      �� 59      " ��6.   .R�5:   "   �� $ border��6)   #��z��69   #��z��6e   #��z��6�   	 . ._�5;   &   �� $ contentPresenter��67   |�.  #��z��6c   #��z��6�   ��. #	 z	 6�   #��z��6   5<   #   5>      5@      5A      5B      ��5C      �� 5D       �� ImageSource$ Resources/close1.png��6    j� Stretch$ Uniform=�6@   5F      �� 5G   
   $��SELECT DATES��6   $
��Left=�6'   $��	82,10,0,0q�6B   $	��Top=�6U   $��32��6m   $	��115��6y   $$��Tw Cen MT Condensed Extra Bold)�6�   $��20(�6�   
�������6�   5I      5J      