   M S B A M L   `   `   `  ���� G  CPerfectSmile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PerfectSmile.ConstantPerfectSmile.Constant      PerfectSmile.Views.Login   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8$prismhttp://prismlibrary.com/  2constant#clr-namespace:PerfectSmile.Constant  !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  .  � 	Resources  �� 
TargetType �� Property �� Value   ErrorToolTipTemplate �� Triggers P� Property P� Value �� RelativeSource	 �� Path��%1  '��       '�� n     '�� 
    �� " ��.���  � ��$ 14(���  � ��$ Right=���  � ��$	 Top=���  � ��$ 0,0,0,0q��� " ��.���  � ��$ Right=���  � ��$	 Top=���  � ��$ 30����  � ��$	 180����  � ��$	 100����  � ��$ 0,0,0,0q��� " ��.���  � ��$
 Left=���  � ��$	 Top=���  � ��$	 180����  � ��$ 30����  �@=�ErrorTemplate# �    P�  �@=�HasError . . ���  �@�ToolTip ��  �� *Self+$)	 #(Validation.Errors)[0].ErrorContent�.��� 
 � ColumnDefinitions
 �� $
��Auto ��� $��10 ��� $��* �.+��� $��0��$��0��$6��0/PerfectSmile;component/Resources/toothLogin.png���� $��2�� �� Orientation$ Vertical=�.+��� $
��Left=�$��Please enter name��$��	0,40,76,0q��� $
��Left=�$��0,5,5,0q����� *Name+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $
��Left=�$��Please enter password��$��0,13,0,0q��� $
��Left=�$��0,5,5,0q����� *
Password+$ TwoWay=�$ PropertyChanged=��� $
��Left=�$��Login��$��0,27,5,0q�����  �� ElementName$ window��$ OneWay=����� *LoginCommand+�� $��Center=�
���  ��$��0,15,5,0q����� *	Message+$ TwoWay=�