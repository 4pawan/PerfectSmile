   M S B A M L   `   `   `  ����G  CPerfectSmile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PerfectSmile.ViewsPerfectSmile.Views  5      $    PerfectSmile.Views.PatientList   *views clr-namespace:PerfectSmile.Views  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8$prismhttp://prismlibrary.com/  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      -   5        $��LstVw��5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  . .  (System.Windows.Interactivity.Interaction   Triggers 5
      F  @Prism.Interactivity.InteractionRequest.InteractionRequestTrigger  5   
   3  -System.Windows.Interactivity.EventTriggerBase   SourceObject 6*   �� *CustomPopupDetailsViewRequest+ �� Mode$ OneWay=�.  (System.Windows.Interactivity.TriggerBase   Actions. 5      +  %Prism.Interactivity.PopupWindowAction     IsModal . !   CenterOverAssociatedObject .    WindowContent 5      +   %PerfectSmile.Views.PatientDetailsView  5      $	��800��6/   $	��700��6;   5      5        5   
    6*   �� *ConfirmDeleteRequest+$ OneWay=�. 5         .  . 65   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��15 �6   .+�5   
   #   PerfectSmile.Views.SearchForm  $��0��6   &	   System.Windows.Controls.DataGrid	  5   
   $��1��6   	 	  AutoGenerateColumns	 .  
 	  
IsReadOnly
 . ��6N   �� *PatientItemSource+$ TwoWay=� 	  Columns 5      0
  *System.Windows.Controls.DataGridTextColumn
  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Patient Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *	PatientId+
  5       $
 Name��6%   $ * 63    6=   �� *Name+   ElementStyle 5!      �� 5"      .�5#      ��  �� Property � �� �� Value$
 Wrap=�6G   5$      5&      
  5'      $ Phone��6%   $ * 64    6>   �� *Phone+
  5(      $ Last visited on��6%   $ * 6>    6H   �� *LastVisitedOn+ �� StringFormat$ 
dd/MM/yyyy��
  5)      $ Last amount paid��6%   $ * 6?    6I   �� *LastAmountPaid+
  5*      $ Balance��6%   $ * 66    6@   �� *	Balance+
  5+      $ Remark��6%   $ * 65    6?   �� *Remark+ 5,      �� 5-      .�5.      ��  � ��$
 Wrap=�6G   5/      51      4  .System.Windows.Controls.DataGridTemplateColumn  52      $
 Edit��6)   $ * 67      CellTemplate 53      �� 54      .R�55      �� $
��Edit��6%   ��64   �� *'%DataContext.NavigateToPatientEditForm+ �� ElementName$ LstVw����56   -   �� 57      59        5:      $ Delete��6)   $ * 69    5;      �� 5<      .R�5=      �� $��Delete��6%   ��66   �� *$"DataContext.DeletePatientBasicInfo+$ LstVw����5>   -   �� 5?      5A        5B      $ Details��6)   $ * 6:    5C      �� 5D      .R�5E      �� $��Details��6%   ��67   �� **(DataContext.NavigateToPatientDetailsView+$ LstVw����5F   -   �� 5G      5I      5K      5L      5M      