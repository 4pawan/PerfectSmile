   M S B A M L   `   `   `  ����G  CPerfectSmile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PerfectSmile.CommonPerfectSmile.Common  5      )    #PerfectSmile.Views.PatientBasicForm   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8$prismhttp://prismlibrary.com/  5      .common!clr-namespace:PerfectSmile.Common  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  .  � 	Resources 5      1   +PerfectSmile.Common.AddEditDisplayConverter   AddEditDisplayConverter �� 
TargetType �� Property �� Value��%�  &	        '��      '�� �       5   
   6)   �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5       � ��$ Right=�64   �� 5       � ��$	 Top=�63   �� 5       � ��$ 5q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$
 Left=�64   �� 5       � ��$	 Top=�62   �� 5       � ��$ 30��6'   �� 5       � ��$	 150��6&   �� 5       � ��$	 100��6)   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5       $	��140 �6   �� 5!      $��* �6    � RowDefinitions 5#   
   �� 5$      $��60 �6   �� 5%      $��40 �6   �� 5&      $��40 �6   �� 5'      $��72 �6   �� 5(      $
��Auto �6   �� 5)      $
��Auto �6    5+   
     ErrorToolTipTemplate �� Triggers P� Property	 P� Value
 �� RelativeSource �� Path��%�  '��       �� 5,      " ��6   .�5-      ��  � ��$
 Left=�68   �� 5.       � ��$	 Top=�66   �� 5/       � ��$	 300��6*   �� 50       � ��$ 30��6+   �� 51       �@=�ErrorTemplate# �  6=    52      P� 53       �@=�HasError	 . . �54      ��  �@�ToolTip 64   �� 
 �� *Self+$) #(Validation.Errors)[0].ErrorContent�55      57      58      .+�59   
   �� $��0��6   $��1��6!   $��19��61   $��0,21,0,0q�6=   $	��279��6O   $
��Left=�6[   $��Segoe Script)�6v   $��16(�6�   $��SemiBold"�6�   �� 5:      .�6   Patient basic form-6'    �� 5;      �6   �� *	PatientId+ �� 	Converter# [   �� Mode$ TwoWay=�5<      �� 5>   
   $��1��6   $��0��6!   $��Name*��61   $��19��6>   $��0,5,5,0q�6J   $��46��6[   �� 5?   
   -   5         ��Name$
 Name��5?   /   $��1��6   $��1��6   $��	0,0.2,0,0q�6�   ��6=   �� *Name+$ TwoWay=� �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5@   
   $��2��6   $��0��6!   $��Phone��61   $��19��6>   $��	0,5.4,5,0q�6J   $��40��6]   �� 5B   
   -   5        $ Phone��5B   /   $��2��6   $��1��6   $��	0,0.4,0,0q�6>   .��6R   .��5C      �� $ Phone�6   $ PropertyChanged=�6#    . $ TwoWay=�6f   5D      �� 5E   
   $��3��6   $��0��6!   $��Remark��61   $��20��6?   �� 5F   
   -   5        $ Remark��5G      $��3��5F      $��1��6   $��2��5H   q   $��63��6�   ��6   �� *Remark+$ PropertyChanged=� . $ TwoWay=�6�   �� 5J   
   $��4��6   $��1��6"    �� Orientation$ 
Horizontal=�62   .+�5K      �� $
��Save��6   $	��147��6D   $
��Left=�6P   ��6$   �� *SaveCommand+6P   �� 5L      $��Clear��6   $	��147��6F   $��5,0,0,0q�6R   ��6%   �� *ClearCommand+6R   5M      �� 5N   
   $��5��6   $��1��6"   $ 
Horizontal=�62   .+�5O      ��  �� Padding$ 0,7,0,0q�6   $
��Left=�6+   
���  ����6W   �� *	Message+�� 5P      $y�Hidden=�6?   ��6   �� *	PatientId+$ TwoWay=�6?   5Q      5S      5T      