   M S B A M L   `   `   `  ����B  >Group03, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Group03Group03  5   	       Group03.Room_Mgmt   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Group03     5   	   -   5          �Name$  winRoomMgmt��5   	    � Title$ Room Management��5   	   $��388.03��6!   $��627.098��61    � 
ResizeMode$ NoResize=�6A    � WindowStartupLocation$ CenterScreen=�6W   .��5	      � $��0,1,0,0q�6   ���	#FFF9F3F3$	��363��63   $	��Top=�6@   .+�5
   
   �� -   5         ��Name$ lblRoomType��5
      $��
Room Type:��6%   $
��Left=�6:   $��
10,143,0,0q�6U   $	��Top=�6i   �� 5   
   -   5        $ lblQuantity��5      $��	Quantity:��6%   $
��Left=�69   $��
10,174,0,0q�6T   $	��Top=�6h   �� 5   
   -   5        $ lblPrice��5      $��Price:��6"   $
��Left=�63   $��
10,206,0,0q�6N   $	��Top=�6b   �� 5   
   -   5         ��Name$ cbxRoomType��5      $
��Left=�6(   $��
88,147,0,0q�6C   $	��Top=�6W   $	��197��6o   $��0��6{   .@�5      �� $y�Hidden=�6   �� 5      $��One King��6   �� 5      $��One King Deluxe��6   �� 5      $��
Two Queens��6   �� 5      $��Two Queens Deluxe��6   �� 5      $��One King Suite��6   �� 5      $!��One King Presidential Suite��6   5      �� 5   
   -   5         ��Name$ txtQuantity��5      $
��Left=�6'   $��23��6B   $��
88,178,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��120��6�   $��1��6�   ���	#FFFFF9F96�   �� 5   
   -   5        $ txtPrice��5      $
��Left=�6$   $��23��6?   $��
88,210,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $	��120��6�   $��2��6�   ���	#FFFFF9F96�   �� 5   
   -   5         ��Name$ btnSave��5      $��Confirm Changes��6"   $
��Left=�6<   $��118,258,0,0q�6W   $	��Top=�6l   $	��111��6�   $��3��6�   $
��Bold"�6�   $	��0.1q�6�   6�   �� 5   
   -	   5        $ 	lblOutput��5      $��Current Room List:��6#   $
��Left=�6@   $��304,120,0,0q�6[   $	��Top=�6p   $
��Bold"�6�   �� 5   
   -
   5        $ btnMainMenu��5      $��	Main Menu��6&   $
��Left=�6:   $��250,311,0,0q�6U   $	��Top=�6j   $	��115��6�   $��4��6�   $	��0.1q�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ lblInstructions��5      $����Choose the room type that you wish to make changes on the right. Enter the desired quantity and/or price for 
that room type and click confirm changes. You can leave a field blank if you wish not to change that field.
The saved changes will be shown on the right.��6)   $
��Left=�6H  $��	10,62,0,0q�6c  $	��Top=�6v  $	��599��6�  �� 5   
   -   5        $ lblTitle��5      $2��,                             Room Management��6"   $
��Left=�6Y   $	��Top=�6t   $��24(�6�   $
��Bold"�6�   
�������$	��619��6�   ��5      �� 5      	 �� EndPoint$	 0.5,1&�6&   
 �� 
StartPoint$
 0.5,0&�67   .��5      �  � Color$ 	#FF5898DC��6#    � Offset$ 0Q�65   � 5       $ 	#FFB5D0EE��6#   $ 0.929Q�65   5!      5#      &   System.Windows.Controls.DataGrid  5$   
   -   5          Name$ dtgRoomList��5$      $
��Left=�6(   $��309,147,0,0q�6C   $	��Top=�6X   $	��140��6p   $	��279��6}   5&      5'      