   M S B A M L   `   `   `  ����G  CPerfectSmile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PerfectSmile.ConstantPerfectSmile.Constant  5          PerfectSmile.Views.Login   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8$prismhttp://prismlibrary.com/  5      2constant#clr-namespace:PerfectSmile.Constant  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  .  � 	Resources 5       �� 
TargetType �� Property �� Value   ErrorToolTipTemplate �� Triggers P� Property P� Value �� RelativeSource	 �� Path��%q  '��       '�� �     '�� �    �� 5	   
   " ��6   .�5
      ��  � ��$ 14(�6)   �� 5       � ��$ Right=�64   �� 5       � ��$	 Top=�63   �� 5       � ��$ 0,0,0,0q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ Right=�64   �� 5       � ��$	 Top=�62   �� 5       � ��$ 30��6'   �� 5       � ��$	 180��6&   �� 5       � ��$	 100��6)   �� 5       � ��$ 0,0,0,0q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$
 Left=�64   �� 5       � ��$	 Top=�62   �� 5       � ��$	 180��6&   �� 5       � ��$ 30��6'   �� 5       �@=�ErrorTemplate# �   69    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 60   ��  �� *Self+$)	 #(Validation.Errors)[0].ErrorContent�5       5"      5#      .��5&      � 
 � ColumnDefinitions
 5'   
   �� 5(      $
��Auto �6   �� 5)      $��10 �6   �� 5*      $��* �6   .+�5-   
   �� $��0��6   $��0��6   $6��0/PerfectSmile;component/Resources/toothLogin.png��6-   6i   �� 5?   
   $��2��6    �� Orientation$ Vertical=�6%   .+�5@      �� $
��Left=�6   $��Please enter name��63   $��	0,40,76,0q�6L   �� 5A      $
��Left=�6   $��0,5,5,0q�6z   ��62   �� *Name+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6z   �� 5B      $
��Left=�6   $��Please enter password��64   $��0,13,0,0q�6Q   �� 5C      $
��Left=�6   $��0,5,5,0q�6~   ��62   �� *
Password+$ TwoWay=�$ PropertyChanged=�6~   �� 5D      $
��Left=�6   $��Login��61   $��0,27,5,0q�5E   p   ��6   ��  �� ElementName$ window��$ OneWay=���6O   �� *LoginCommand+6p   �� 5F      $��Center=�6   
���  ��$��0,15,5,0q�6m   ��66   �� *	Message+$ TwoWay=�6m   5G      5J      5K      