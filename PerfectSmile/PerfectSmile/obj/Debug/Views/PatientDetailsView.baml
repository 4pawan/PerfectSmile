   M S B A M L   `   `   `  ����G  CPerfectSmile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PerfectSmile.ViewsPerfectSmile.Views  5      +    %PerfectSmile.Views.PatientDetailsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8$prismhttp://prismlibrary.com/  5      ,views clr-namespace:PerfectSmile.Views  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  . .  (System.Windows.Interactivity.Interaction   Triggers 5
      F  @Prism.Interactivity.InteractionRequest.InteractionRequestTrigger  5   
   3  -System.Windows.Interactivity.EventTriggerBase   SourceObject 6*   �� *(&ConfirmDeleteRequestPatientHistoryInfo+ �� Mode$ OneWay=�.  (System.Windows.Interactivity.TriggerBase   Actions. 5      +  %Prism.Interactivity.PopupWindowAction     IsModal . !   CenterOverAssociatedObject . 65   5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	DetailsVw��5      $��0��6%      AutoGenerateColumns .     
IsReadOnly . ��6`   �� *#!Notification.PatientDetailsSource+$ TwoWay=�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,	  &System.Windows.Controls.DataGridColumn
 	  Header$
 
Visited On��6%    	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ *
 69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *	VisitedOn+ �� StringFormat$ 
dd/MM/yyyy��  5      $
 Treatment Done��6%   $ *
 6=    6G   �� *TreatmentDone+   ElementStyle 5      �� 5      .�5      ��  �� Property � �� �� Value$
 Wrap=�6G   5      5        5      $
 Next Appointment��6%   $ *
 6?    6I   �� *NextAppointment+$ 
dd/MM/yyyy��  5      $
 Payment Done��6%   $ *
 6;    6E   �� *PaymentDone+  5       $
 Balance��6%   $ *
 66    6@   �� *	Balance+  5!      $
 Additional Comment��6%   $ *
 6A    6K   �� *AdditionalComment+ 5"      �� 5#      .�5$      ��  � ��$
 Wrap=�6G   5%      5'      4  .System.Windows.Controls.DataGridTemplateColumn  5(      $
 Delete��6)   $ *
 69      CellTemplate 5)      �� 5*      .R�5+      �� $��Delete��6%   ��66   �� *&$DataContext.DeletePatientHistoryInfo+ �� ElementName$ 	DetailsVw����5,   -   �� 5-      5/      51      52      53      