   M S B A M L   `   `   `  ����G  CPerfectSmile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullw@clr-namespace:PerfectSmile.Views.UserControl.AutoCompleteTextBox2PerfectSmile.Views.UserControl.AutoCompleteTextBox  5      +    %PerfectSmile.Views.PatientHistoryForm   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8$prismhttp://prismlibrary.com/  5      ZautoCompleteTextBox@clr-namespace:PerfectSmile.Views.UserControl.AutoCompleteTextBox  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  .  � 	Resources 5	       �� 
TargetType �� Property �� Value��%�  '��       '�� �     �� 5
   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$ Right=�64   �� 5       � ��$	 Top=�63   �� 5       � ��$ 5q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$
 Left=�64   �� 5       � ��$	 Top=�62   �� 5       � ��$ 30��6'   �� 5       � ��$	 150��6&   �� 5       � ��$	 100��6)   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��145 �6   �� 5      $��* �6    � RowDefinitions 5    
   �� 5!      $��60 �6   �� 5"      $��40 �6   �� 5#      $��40 �6   �� 5$      $��40 �6   �� 5%      $��40 �6   �� 5&      $��40 �6   �� 5'      $��40 �6   �� 5(      $��40 �6   �� 5)      $��40 �6    5+   
      ErrorToolTipTemplate �� Triggers P� Property	 P� Value
 �� RelativeSource �� PathL   FPerfectSmile.Views.UserControl.AutoCompleteTextBox.AutoCompleteTextBox(  "System.Windows.Controls.DatePicker��%�  '��       '  �    '      �� 5,      " ��6   .�5-      ��  � ��$
 Left=�68   �� 5.       � ��$	 Top=�66   �� 5/       � ��$	 300��6*   �� 50       � ��$ 30��6+   �� 51       �@=�ErrorTemplate# �   6=    52      P� 53       �@=�HasError	 . . �54      ��  �@�ToolTip 64   �� 
 �� *Self+$) #(Validation.Errors)[0].ErrorContent�55      57      �� 58      "  6   .�59      ��  � ��$
 Left=�68   �� 5:       � ��$	 Top=�66   �� 5;       � ��$	 300��6*   �� 5<       � ��$ 30��6+   �� 5=       �@=�ErrorTemplate# �   6=    5>      P� 5?       �@=�HasError	 . . �5@      ��  �@�ToolTip 64   �� 
 �� *Self+$) #(Validation.Errors)[0].ErrorContent�5A      5C      �� 5D      "  6   .�5E      ��  � ��$
 Left=�68   �� 5F       � ��$	 Top=�66   �� 5G       � ��$	 300��6*   �� 5H       � ��$ 30��6+   �� 5I       �@=�ErrorTemplate# �   6=    5J      P� 5K       �@=�HasError	 . . �5L      ��  �@�ToolTip 64   �� 
 �� *Self+$) #(Validation.Errors)[0].ErrorContent�5M      5O      5P      .+�5R   
   �� $��0��6   $��1��6"   $��Patient's history form��62   $��Segoe Script)�6P   $��16(�6j   $
��Left=�6x   $��SemiBold"�6�   $��Bottom=�6�   �� 5T   
   $��1��6   $��0��6"   $��Select Patient Id*��62     5U   
   $��1��62   $��1��6?   $
��Left=�6�   $	��Top=�6
  $��30��6"  $	��300��6.     Source 6O   �� *AutoCompleteSource+ �� Mode$ TwoWay=�   TextVal 6�   �� *	PatientId+ �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�$ TwoWay=�6.  �� 5W   
   $��2��6   $��0��6"   $��Treatment Done��62   �� 5X   
   $��2��6   $��1��6   ��6/   �� *TreatmentDone+$ TwoWay=�$ PropertyChanged=��� 5Z   
   $��3��6   $��0��6"   $��Payment Done*��62   �� 5[   
   $��3��6   $��1��6   ��6/   �� *PaymentDone+$ TwoWay=�$ PropertyChanged=��� 5]   
   $��4��6   $��0��6"   $��Balance*��62   �� 5^   
   $��4��6   $��1��6   ��6/   �� *	Balance+$ TwoWay=�$ PropertyChanged=��� 5`   
   $��5��6   $��0��6"   $��Next Appointment��62     5a   
   $��5��6C   $��1��6P   $	��300��6�   $��30��6�   $
��Left=�6�      DisplayDateStart 6   �� *DisplayDateStart+   Text 6`   �� *NextAppointment+$ TwoWay=�$ PropertyChanged=�6�   �� 5c   
   $��6��6   $��0��6"   $��Additional Comment��62   �� 5d   
   $��6��6   $��1��6   ��6/   �� *AdditionalComment+$ TwoWay=�$ PropertyChanged=��� 5f   
   $��7��6   $��1��6"    �� Orientation$ 
Horizontal=�62   .+�5g      �� $
��Save��6   $	��147��6D   ��6$   �� *SaveCommand+6D   �� 5h      $��Clear��6   $	��147��6F   $��5,0,0,0q�6R   ��6%   �� *ClearCommand+6R   5i      �� 5k   
   $��8��6   $��1��6"   $ 
Horizontal=�62   .+�5l      ��  �� Padding$ 0,7,0,0q�6   $
��Left=�6+   
���  ����6W   �� *	Message+5m      5n      5o      