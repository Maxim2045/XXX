   M S B A M L   `   `   `  ���� I  EWpfAppVedomost, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfAppVedomostWpfAppVedomost  D @FluentWPF, Version=0.8.0.6, Culture=neutral, PublicKeyToken=nullP6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPFSourceChord.FluentWPF     WpfAppVedomost.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:WpfAppVedomost     V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  ?fw6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPF  -     �Name$  Vedomost��)  #SourceChord.FluentWPF.AcrylicWindow   Enabled .  � Title$ Ведомайзер��$
��1250��$
��1200��$��0,0,50,0q�$��14(�.���  � ColumnDefinitions �� $
��56.8 ��� $��1094.4 ��� $
��Auto �.+�]� $��
0,0,26.2,0q�$��2��.+�c� $	��Top=�$��0,0,174.2,0q�$��Right=�$	��850��
�������.@��� d� -   $��btnBold��$ ��EditingCommands.ToggleBold��.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
FormatBold=�$��10q�$��25��$��25��d� -   $��	btnItalic��$"��EditingCommands.ToggleItalic��.��  $ FormatItalic=�$��10q�$��25��$��25��d� -   $��btnUnderline��$%��EditingCommands.ToggleUnderline��.��  $ FormatUnderline=�$��10q�$��25��$��25���� �� -   $��cmbFontFamily��$	��150���� -   $��cmbFontSize��$��50�� �� 
IsEditable . �� -    ��Name$ docBox��$��20,5.2,94.4,41q�$	��850��
������� �� 
CaretBrush �	#FF251313���	#892214F0$��1q�$��Times New Roman)�$��12(��� $��904.4,10,21.8,0q�$��1��.+��� -    �� Orientation$ 
Horizontal=�	 � Cursor$
	 Hand��.+��� -	   
���   ���Z� ��Z� .��  $ 	ArrowLeft=��� $��Меню��$��16(�$��10q�$��Center=�$��90���� $��Действия��$��15q�$��DemiBold"��� $��15(�.@��� $��1q�.���� -
   $ 
Horizontal=�$
	 Hand��.+�  $ 
FileUpload=�$��15q��� $��Сформировать��$��Center=��� $��1q�.���� -   $ 
Horizontal=�$
	 Hand��.+�  $
 Edit=�$��15q��� $ ��Редактировать��$��Center=��� $��1q�.���� -   $ 
Horizontal=�$
	 Hand��.+�  $ ContentSave=�$��15q��� $��Сохранить��$��Center=��� $��1q�.���� -   $ 
Horizontal=�$
	 Hand��.+�  $ Printer=�$��15q��� $��Печать��$��Center=�