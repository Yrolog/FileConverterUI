   M S B A M L   `   `   `  ����J  FFileConverterUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:FileConverterUIFileConverterUI  5   	        FileConverterUI.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:FileConverterUI     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   .+�5   
   �� -   5         ��Name$ EnterTextBox��5       �� TextWrapping$
 Wrap=�5       �� AcceptsReturn$
 True��5      $��10,32,10,10q�5      $��0��5      $��0��5      5   ;   �� 5   
   -   5        $ 
GetTextBox��5      $ NoWrap=�5      $��Visible=�5      $��10,32,10,10q�5       $��1��5!      $��0��5"      6!   �� 5$   
   -   5         ��Name$ isBadEng��5$      $��10,10,123,158q�5%      $��0��5&      $��1��5'      .��5(   *   ><Использовать "плохой" английский6L   � 5*   
   -   5         �Name$ SelectButtonPopup��5*       � 	StaysOpen$ False��6+   $��Relative=�6=   $	��180��6R   	 � AllowsTransparency$
	 True��5+   
   .��5,      �� $
��Wrap=�6   $	��180��6,   
��� ���
 J� Opacity$	
 0.8Q�6L   :8Тект скопирован в буфер обмена5.      5/      �� 51   
   -   5         ��Name$ SelectAllGetTextBox��51      $!��Выделить текст��52      $��90��53      $��50��54      $��90��55      $��50��56      $
��Left=�57      $	��Top=�58      $��90��59      $��50��6   $��1��5:      $��1��6   $��	10,10,0,0q�5;      6$   o� 5<   
   $��20��6   $	��Top=�6   .@�5=      m� -   5        $
��File��5=      .@�6@   #!Загрузить таблицу5?      5A      5B      5C      