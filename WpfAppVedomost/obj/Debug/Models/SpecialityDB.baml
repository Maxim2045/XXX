   M S B A M L   `   `   `  ����D  @FluentWPF, Version=0.8.0.6, Culture=neutral, PublicKeyToken=nullP6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPFSourceChord.FluentWPF  5   	   I EWpfAppVedomost, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfAppVedomostWpfAppVedomost 5   	   !   WpfAppVedomost.SpecialityDB   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   ?fw6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPF  5   	   (localclr-namespace:WpfAppVedomost  5   	   -   5          �Name$  Sp��5   	    � Title$, &Направления и группы��5
   	   $	��450��6&   $	��800��63   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ specialityList��5   /      AutoGenerateColumns .  ��6G   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Код��6>      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6K      FontSize$ 16Q�6W   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� *Code+6W     5      $ Направление��6H   $ 16Q�6]   	 6%   �� *NameSpeciality+6]   5      �� 5   
   $��2��6   
 �� Orientation$
 
Horizontal=�6"   $��Center=�6;   .+�5      �� -   5        
���   �.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�6*   5      �� 5      -   5        $��Меню��5      
���   �$��16(�6J   $��10q�6X   $��Center=�6d   $��90��6�   
�������6�   �� 5      -   5        $��Добавить��5      $��10q�6(   
�������6F   �� 5      -   5        $��Изменить��5      $��10q�6(   
�������6G   �� 5       -   5        $-��'Обучающиеся студенты��5       $��10q�64   
�������6V   5!      5;      5<      