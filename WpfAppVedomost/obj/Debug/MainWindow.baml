   M S B A M L   `   `   `  ����I  EWpfAppVedomost, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfAppVedomostWpfAppVedomost  5   	   D @FluentWPF, Version=0.8.0.6, Culture=neutral, PublicKeyToken=nullP6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPFSourceChord.FluentWPF 5	   	       WpfAppVedomost.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WpfAppVedomost     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   ?fw6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPF  5	   	   -   5          �Name$  Vedomost��5   	   )  #SourceChord.FluentWPF.AcrylicWindow   Enabled .  � Title$ Ведомайзер��5   	   $
��1250��6   $
��1200��6*   $��0,0,50,0q�69   $��14(�6K   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��56.8 �6   �� 5      $��1094.4 �6   �� 5      $
��Auto �6   .+�5   
   ]� $��
0,0,26.2,0q�6   $��2��6(   .+�5      c� $	��Top=�6   $��0,0,174.2,0q�6+   $��Right=�6@   $	��850��6\   
�������.@�5      �� d� 5      -   5        $��btnBold��5   D   $ ��EditingCommands.ToggleBold��6   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
FormatBold=�6.   $��10q�6@   $��25��6L   $��25��6W   5      d� 5      -   5        $��	btnItalic��5   F   $"��EditingCommands.ToggleItalic��6   .��5        $ FormatItalic=�6.   $��10q�6B   $��25��6N   $��25��6Y   5      d� 5      -   5        $��btnUnderline��5   I   $%��EditingCommands.ToggleUnderline��6   .��5        $ FormatUnderline=�6.   $��10q�6E   $��25��6Q   $��25��6\   5      �� 5      �� 5      -   5        $��cmbFontFamily��5      $	��150��60   6<   �� 5       -   5        $��cmbFontSize��5       $��50��6.    �� 
IsEditable . 6K   5!      �� 5"      -   5         ��Name$ docBox��5"      $��20,5.2,94.4,41q�6*   $	��850��6n   
������� �� 
CaretBrush �	#FF251313���	#892214F0$��1q�6�   $��Times New Roman)�6�   $��12(�6�   5#      �� 5$   
   $��904.4,10,21.8,0q�6   $��1��6.   .+�5%      �� -   5         �� Orientation$ 
Horizontal=�5%      	 � Cursor$
	 Hand��6I   .+�5&      �� -	   5        
���   ���5&   ,   Z� ��6B   Z� .��5'        $ 	ArrowLeft=�6.   5(      �� 5)      $��Меню��6   $��16(�6(   $��10q�66   $��Center=�6B   $��90��6]   5*      �� 5+      $��Действия��6   $��15q�6(   $��DemiBold"�64   �� 5,      $��15(�6   .@�5-      �� $��1q�6   .��5.      �� -
   5        $ 
Horizontal=�5.   !   $
	 Hand��6R   .+�5/        $ 
FileUpload=�62   $��15q�6D   �� 50      $��Сформировать��6$   $��Center=�68   51      52      �� 53      $��1q�6   .��54      �� -   5        $ 
Horizontal=�54   !   $
	 Hand��6Q   .+�55        $
 Edit=�62   $��15q�6>   �� 56      $ ��Редактировать��6$   $��Center=�69   57      58      �� 59      $��1q�6   .��5:      �� -   5        $ 
Horizontal=�5:   !   $
	 Hand��6Q   .+�5;        $ ContentSave=�62   $��15q�6E   �� 5<      $��Сохранить��6$   $��Center=�65   5=      5>      �� 5?      $��1q�6   .��5@      �� -   5        $ 
Horizontal=�5@   !   $
	 Hand��6R   .+�5A        $ Printer=�62   $��15q�6A   �� 5B      $��Печать��6$   $��Center=�62   5C      5D      5E      5F      5G      5H      