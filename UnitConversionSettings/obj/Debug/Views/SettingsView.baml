   M S B A M L   `   `   `  ����Q  MUnitConversionSettings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:UnitConversionSettings.ViewsUnitConversionSettings.Views  5      ]3clr-namespace:UnitConversionSettings.UnitConversion%UnitConversionSettings.UnitConversion  5      /    )UnitConversionSettings.Views.SettingsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:UnitConversionSettings.Views     5      NunitConversion3clr-namespace:UnitConversionSettings.UnitConversion     5        � 	Resources  5       �� 
TargetType �� Property �� Value��%�  '��       '�� r     '�� �     �� 5   
   " ��6   .�5      ��  � ��$	 156��6&   �� 5       � ��$ 4,4,4,4q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 4,4,4,4q�6'   �� 5       � ��$ Center=�62   6C   5      �� 5   
   " ��6   .�5      ��  � ��$ 4,4,4,4q�6'   �� 5       � ��$ Center=�62   6C   5      5      .��5      �   5   
    �� BasedOn��%b   '��       7���� 5      " ��6   8   .�5      ��  � ��$
 Left=�68   6G   5      5        � ColumnDefinitions 5!   
   �� 5"      $
��Auto �6   �� 5#      $
��Auto �6   �� 5$      $��* �6    � RowDefinitions 5&   
   �� 5'      $
��Auto �6   �� 5(      $
��Auto �6   �� 5)      $
��Auto �6   �� 5*      $
��Auto �6   �� 5+      $
��Auto �6   �� 5,      $
��Auto �6   .+�5/   
   �� $��0��6   $��0��6$   $��Settings��61   �� 50   
   $��1��6   $��0��6#    �� DisplayMemberPath$
 Name��53       �� SelectedValuePath$
 Name��54      ��51      �� 	 �� Path$	 MeasurementSystems�
 �� NotifyOnSourceUpdated
 .  �� SelectedItem 52      �� $	 SelectedMeasurementSystem�54      �� 55   
   $��2��6   $��0��6"   $
��Left=�56      ��55   /   �� * CreateMeasurementSystemCommand+.��57      �� $��Add Measurement System��6   68   58      �� 5:   
   $��0��6   $��1��6$   $��Flight Distance��61   �� 5;   
   $��1��6   $��1��6#   $
 Name��5>      ��5<      �� *DistanceUnits+
 .  5=      �� *SelectedDistanceUnit+5>      �� 5@   
   $��0��6   $��2��6$   $��
Total Area��61   �� 5A   
   $��1��6   $��2��6#   $
 Name��5D      ��5B      �� *Areas+
 .  5C      �� *SelectedArea+5D   .   �� 5F   
   $��0��6   $��3��6$   $��Charging Rate��61   �� 5G   
   $��1��6   $��3��6#   $
 Area��5J      ��5H      �� *ChargingRates+
 .  �� SelectedValue 5I      �� *SelectedChargingRateArea+5J   .   �� 5L   
   $��0��6   $��4��6$   $��Invoice Report��61   �� 5M   
   $��1��6   $��4��6#   $
 Area��5P      ��5N      �� *InvoiceReports+
 .  5O      �� *SelectedInvoiceReportArea+5P   .   5R      5S      