   M S B A M L   `   `   `  ����B  >Group03, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Group03Group03  5   	        Group03.Reservation_Report   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Group03     5   	   -   5          �Name$  WinReservationReport��5   	    � Title$ Reservation_Report��5   	   $	��550��6$   $	��817��61    � WindowStartupLocation$ CenterScreen=�6=   .��5	      � -   5         �Name$
 grid��5	      $��0,0,2,0q�6   $	��519��6*   $	��Top=�67   ���	#FFF9F3F3 � ColumnDefinitions 5
   
   �� 5      $
��365* �6   �� 5      $
��366* �6   .+�5   
   �� -   5         ��Name$ 	grpFilter��5      $��Filter��6&   $
��Left=�66   $	��102��6Q   $��
113,61,0,0q�6^   $	��Top=�6r   $	��575��6�   $
��Bold"�6�   $��2��6�   .��5      �� -   5         ��Name$ txtLastName��5      $
��Left=�6+   $��23��6F   $��
376,23,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $	��120��6�   $��2��6�   ���	#FFFFF9F96�   5      �� 5   
   -   5         ��Name$ lblTitle��5      $A��;                                         Reservation Report��6"   $
��Left=�6h   $	��Top=�6�   $��24(�6�   $
��Bold"�6�   $��2��6�   $��50��6�   
�������$	��807��6�   ��5      �� 5      	 �� EndPoint$	 0.5,1&�6&   
 �� 
StartPoint$
 0.5,0&�67   .��5      �  � Color$ 	#FF5898DC��6#    � Offset$ 0Q�65   � 5      $ 	#FFB5D0EE��6#   $ 0.929Q�65   5      5      �� 5   
   -   5        $ lblStartDate��5      $��Start Date:��6&   $
��Left=�6<   $��
139,95,0,0q�6W   $	��Top=�6k    J� RenderTransformOrigin$ 0.439,-0.731&�6�   $��26��6�   $��65��6�   �� 5   
   -   5        $ 
lblEndDate��5      $��	End Date:��6$   $
��Left=�68   $��143,121,0,0q�6S   $	��Top=�6h   $��26��6�   $��61��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dtpStartDate��5      $
��Left=�6+   $��
209,95,0,0q�6F   $	��Top=�6Z   ��. $��0��6�   $��24��6�   $	��102��6�   ���	#FFFFF9F96�     5   
   -	   5        $ 
dtpEndDate��5      $
��Left=�6)   $��209,124,0,0q�6D   $	��Top=�6Y   ��. $��1��6�   $��24��6�   $	��102��6�   ���	#FFFFF9F96�   �� 5   
   -
   5        $ lblLastName��5      $��
Last Name:��6%   $
��Left=�6:   $��	10,95,0,0q�6U   $	��Top=�6h   $ 0.65,-1.038&�6�   $��26��6�   $��69��6�   $��1��6�   �� 5   
   -   5         ��Name$ 	btnSearch��5      $��Search��6$   $
��Left=�65   $��93,133.03,0,0q�6P   $	��Top=�6g   $��75��6   $��3��6�   $��1��6�   $��20��6�   $	��0.1q�6�   $
��Bold"�6�   6�   �� 5    
   -   5        $ btnMainMenu��5       $��	Main Menu��6&   $
��Left=�6:   $��351,476,-50.052,0q�6U   $	��Top=�6p   $	��102��6�   $��4��6�   $��20��6�   $
��Bold"�6�   $	��0.1q�6�   6�   &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ dtgReservation��5!      $
��Left=�6+   $	��274��6F   $��
10,184,0,0q�6S   $	��Top=�6g   $	��797��6   $��2��6�   5#      5$      