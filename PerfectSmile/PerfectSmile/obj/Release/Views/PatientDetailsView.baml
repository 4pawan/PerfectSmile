   M S B A M L   `   `   `  ���� G  CPerfectSmile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PerfectSmile.ViewsPerfectSmile.Views  +    %PerfectSmile.Views.PatientDetailsView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8$prismhttp://prismlibrary.com/  ,views clr-namespace:PerfectSmile.Views  c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  . .  (System.Windows.Interactivity.Interaction   Triggers F  @Prism.Interactivity.InteractionRequest.InteractionRequestTrigger  3  -System.Windows.Interactivity.EventTriggerBase   SourceObject �� *(&ConfirmDeleteRequestPatientHistoryInfo+ �� Mode$ OneWay=�.  (System.Windows.Interactivity.TriggerBase   Actions. +  %Prism.Interactivity.PopupWindowAction     IsModal . !   CenterOverAssociatedObject . .��� .+�&   System.Windows.Controls.DataGrid  -   $��	DetailsVw��$��0��   AutoGenerateColumns .     
IsReadOnly . ���� *#!Notification.PatientDetailsSource+$ TwoWay=�	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn
 	  Header$
 
Visited On�� 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ *
 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	VisitedOn+ �� StringFormat$ 
dd/MM/yyyy��  $
 Treatment Done��$ *
  �� *TreatmentDone+   ElementStyle �� .���  �� Property � �� �� Value$
 Wrap=�  $
 Next Appointment��$ *
  �� *NextAppointment+$ 
dd/MM/yyyy��  $
 Payment Done��$ *
  �� *PaymentDone+  $
 Balance��$ *
  �� *	Balance+  $
 Additional Comment��$ *
  �� *AdditionalComment+ �� .���  � ��$
 Wrap=�4  .System.Windows.Controls.DataGridTemplateColumn  $
 Delete��$ *
    CellTemplate �� .R��� $��Delete������ *&$DataContext.DeletePatientHistoryInfo+ �� ElementName$ 	DetailsVw������ 