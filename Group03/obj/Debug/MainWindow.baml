   M S B A M L   `   `   `  ����B  >Group03, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Group03Group03  5   	       Group03.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Group03     5   	   -   5          �Name$  winMainMenu��5   	   $	��400��5      $��565.196��6'    � 
ResizeMode$ NoResize=�67    � Title$ Hotel Reservation��6M    � WindowStartupLocation$ CenterScreen=�6g   .��5      �  � ColumnDefinitions 5	   
   �� 5
      $
��280* �6   �� 5      $
��279* �6   .+�5   
   �� -   5         ��Name$ imgBackground��5      $
��Left=�6'   $	��372��6B   $	��Top=�6O   $	��562��6g   $��background.jpg��6s   $��2��6�   $��	0,0,-3,-1q�6�    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 3Q�6   5      �� 5   
   -   5         ��Name$ lblTitle��5      $��
Bali Hotel��6"   $
��Left=�67   $��
170,62,0,0q�6R   $	��Top=�6f   $
��Bold"�6~   $��48(�6�   
�������$��Garamond)�6�   $��2��6�   $��64��6�   $	��220��6�   ��6�   Z� 6�   �� 5   
   -   5        	 ��Name$	 btnNewReservation��5      $��Create Reservation��6,   $
��Left=�6I   $��
55,202,0,0q�6d   $	��Top=�6x   $	��115��6�   $��0��6�   
�������$��20��6�   $	��0.1q�6�   ��6�   Z�  5      3  -System.Windows.Media.Effects.DropShadowEffect  5      
   ShadowDepth$
 2Q�6#   5      �� 5   
   -   5        $	 btnRoomMgmt��5      $��Manage Rooms��6&   $
��Left=�6=   $��112,202,0,0q�6X   $	��Top=�6m   $	��115��6�    J� RenderTransformOrigin$ 1.578,-0.567&�6�   $��2��6�   
�������$��1��6�   $��20��6�   $	��0.1q�6�    5        5      $
 2Q�6#   5      �� 5   
   -   5        $	 btnReservationRpt��5      $��View Reservation Reports��6,   $
��Left=�6O   $��199,202,0,0q�6j   $	��Top=�6   $	��162��6�   $��1��6�   
�������$��2��6�   $��20��6�   $	��0.1q�6�    5        5       $
 2Q�6#   5"      �� 5#   
   -   5        $	 btnExit��5#      $��Quit Program��6"   $
��Left=�69   $��232,260,0,0q�6T   $	��Top=�6i   $��92��6�   $��3��6�   $��2��6�   $��20��6�   
����������	#FFD40000$	��0.1q�6�    5$        5%      $
 2Q�6#   5'      �� 5(   
   -   5        $ lblInstructions��5(      $&�� What would you like to do today?��6)   $
��Left=�6T   $��158,139,0,0q�6o   $	��Top=�6�   
�������$��18(�6�   $��Garamond)�6�   $��2��6�   $��30��6�   $	��245��6	  ��6�   Z� 6	  5*      5+      