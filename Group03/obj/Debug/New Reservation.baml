   M S B A M L   `   `   `  ����B  >Group03, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Group03Group03  5   	       Group03.New_Reservation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Group03     5   	   -   5          �Name$  winNewReservation��5   	    � Title$ Create New Reservation��5   	   $��404.73��6(   $��617.644��68    � 
ResizeMode$ NoResize=�6H    � WindowStartupLocation$ CenterScreen=�6^   .��5	      � ���	#FFF9F3F3 � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� $��Quote��6   $
��Left=�6"   $	��235��6=   $��
307,66,0,0q�6J   $	��Top=�6^   $	��282��6v   
�������$
��Bold"�6�   �� 5   
   -   5         ��Name$ grpReservationInfo��5      $��Reservation Details��6/   $
��Left=�6L   $	��235��6g   $��	13,66,0,0q�6t   $	��Top=�6�   $	��267��6�   $
��Bold"�6�   
�������6�   �� 5   
   -   5         ��Name$ lblTitle��5      $@��:                                          Room Reservation��6"   $
��Left=�6g   $	��Top=�6�   $
��Bold"�6�   $��20(�6�   $��43��6�   $	��612��6�   
���������5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      � 	 � Color$	 	#FF5898DC��6#   
 � Offset$
 0Q�65   � 5      $	 	#FFB5D0EE��6#   $
 0.929Q�65   5      5      �� 5   
   -   5        $ lblRoomType��5      $��
Room Type:��6%   $
��Left=�6:   $��	28,92,0,0q�6U   $	��Top=�6h   $��26��6�   $��72��6�   �� 5   
   -   5         ��Name$ cbxRoomType��5      $
��Left=�6(   $��
118,95,0,0q�6C   $	��Top=�6W   $	��145��6o   $��0��6{   $��22��6�   .@�5      �� $��One King��6   �� 5      $��One King Deluxe��6   �� 5      $��
Two Queens��6   �� 5      $��Two Queen Deluxe��6   �� 5      $��One King Suite��6   �� 5       $!��One King Presidential Suite��6   5!      �� 5"   
   -   5        $ 
lblNoRooms��5"      $��No. of Rooms:��6$   $
��Left=�6<   $��
28,123,0,0q�6W   $	��Top=�6k   $��26��6�   $��85��6�   (  "System.Windows.Controls.DatePicker  5#   
   -   5          Name$ 
dtpCheckIn��5#      $
��Left=�6)   $��118,157,0,0q�6D   $	��Top=�6Y   ��. $��2��6�   $��24��6�   $	��102��6�   ���	#FFFFF9F96�   �� 5$   
   -   5        $ 
lblCheckIn��5$      $��	Check In:��6$   $
��Left=�68   $��
28,156,0,0q�6S   $	��Top=�6g   $��26��6   $��58��6�   �� 5%   
   -	   5         ��Name$ txtNoOfRooms��5%      $
��Left=�6(   $��22��6C   $��118,127,0,0q�6O    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $��24��6�   $��1��6�   ���	#FFFFF9F96�   �� 5&   
   -
   5        $ lblCheckOut��5&      $��
Check Out:��6%   $
��Left=�6:   $��
28,190,0,0q�6U   $	��Top=�6i   $��26��6�   $��68��6�     5'   
   -   5        $ dtpCheckOut��5'      $
��Left=�6*   $��118,191,0,0q�6E   $	��Top=�6Z   ��. $��3��6�   $��24��6�   $	��102��6�   6�   �� 5(   
   -   5         ��Name$ btnQuote��5(      $��Calculate Quote��6#   $
��Left=�6=   $��
83,252,0,0q�6X   $	��Top=�6l   $	��124��6�   $��4��6�   $��20��6�   $
��Bold"�6�   $	��0.1q�6�   6�   �� 5)   
   -   5        $ btnReservation��5)      $��Create Reservation��6)   $
��Left=�6F   $��391,326,0,0q�6a   $	��Top=�6v   $	��118��6�   $��5��6�   $��20��6�   $
��Bold"�6�   $	��0.1q�6�   6�   �� 5*   
   -   5        $ btnMainMenu��5*      $��	Main Menu��6&   $
��Left=�6:   $��105,326,0,0q�6U   $	��Top=�6j   $��85��6�   $��6��6�   $��20��6�   $	��0.1q�6�   $
��Bold"�6�   6�   �� 5+   
   -   5        $ lblNoOfNights��5+      $��Number of Nights:��6'   $
��Left=�6C   $��
316,91,0,0q�6^   $	��Top=�6r   $
��Bold"�6�   �� 5,   
   -   5        $ lblRatePerNight��5,      $��Rate per Night:��6)   $
��Left=�6C   $��316,122,0,0q�6^   $	��Top=�6s   $
��Bold"�6�   �� 5-   
   -   5        $ lblSubtotal��5-      $��Subtotal��6%   $
��Left=�68   $��316,153,0,0q�6S   $	��Top=�6h   $
��Bold"�6�   �� 5.   
   -   5        $ lblTax��5.      $��	Tax (7%):��6    $
��Left=�64   $��316,184,0,0q�6O   $	��Top=�6d   $
��Bold"�6|   �� 5/   
   -   5        $ 
lblConvFee��5/      $#��Convenience Fee:
($10/night)��6$   $
��Left=�6T   $��316,215,0,0q�6o   $	��Top=�6�   $
��Bold"�6�   �� 50   
   -   5        $ lblTotal��50      $��Total:��6"   $
��Left=�63   $��316,265,0,0q�6N   $	��Top=�6c   $
��Bold"�6{   �� 51   
   -   5        $ lblConvFeeOut��51      $��$0��6'   $
��Left=�64   $��432,215,0,0q�6O   $	��Top=�6d   �� 52   
   -   5        $ lblTotalOut��52      $��$0��6%   $
��Left=�62   $��432,265,0,0q�6M   $	��Top=�6b   �� 53   
   -   5        $ 	lblTaxOut��53      $��$0��6#   $
��Left=�60   $��432,184,0,0q�6K   $	��Top=�6`   �� 54   
   -   5        $ lblSubtotalOut��54      $��$0��6(   $
��Left=�65   $��432,153,0,0q�6P   $	��Top=�6e   �� 55   
   -   5        $ lblRatePerNightOut��55      $��$0��6,   $
��Left=�69   $��432,122,0,0q�6T   $	��Top=�6i   �� 56   
   -   5        $ lblNoOfNightsOut��56      $��0��6*   $
��Left=�66   $��
432,91,0,0q�6Q   $	��Top=�6e   58      59      