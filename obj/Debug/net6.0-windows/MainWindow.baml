   M S B A M L   `   `   `  ����D  @PoolEight, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PoolEight	PoolEight  5   	       PoolEight.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   #localclr-namespace:PoolEight  5   	   $
��1080��5
   	   $
��1920��6     � WindowState$  	Maximized=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � 	Resources 5         ImageButton �� 
TargetType �� Property �� Value �� 
TargetType �� Padding��%�   &	        �� 5   
   " ��6$   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 0,200,0,200q�5      
������ ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      5      .��5      � .+�5    
   � $
}�True��6   $
��Auto��6#   $
��Auto��60   ��5!      
� 5"      	 
� GradientOrigin$	 0.5, 0.5&�6&   
 
� Center$
 0.5, 0.5&�6@    
� RadiusX$	 0.5Q�6R    
� RadiusY$	 0.5Q�6`   ��5$      �  � Color$ LightSlateGray��6'    � Offset$ 0Q�6>   � 5%      $ DarkSlateGray��6'   $ 1Q�6=   5'      .+�5)      �� -   5        #��[  5)      .��5*      �� .+�5+      �� $	��547��6   $	��200��6*   .+�5,      �� $$��/Resources\Images\capsule.png ��6     K� ZIndex$ 2��6H   $	��547��6Y   �� 5-      -   5         ��Name$
 Half��5-   !   $	��200��6/   $	��547��6;   $ 1��6H   5.      �� 5/      $	��970��6   $	��547��6)   ��50      �� 51       �� ImageSource$! /Resources\Images\table.png��6)   .+�53      �� -   5        $ Table��53   !   $	��970��60   $	��547��6<   $
}�True��6I   ��54      �� 55   "   $! /Resources\Images\table.png��6-    J� OpacityMask 57      �� 58   "   $&  /Resources\Images\table_mask.png��6-   5:      �� 5;      -   5         ��Name$ Overlay��5;       $	��970��61   $	��547��6=   $
��None=�6J   5<      �� 5=      $	��547��6   $	��200��6*   .+�5>      �� $#��/Resources\Images\capsule.png��6    $ 2��6G   $	��547��6X   �� 5?      -   5        $
 Full��5?   !   $	��200��6/   $	��547��6;   $ 1��6H   5@      5A      5B      �� 5C      -   5        $ Queue��5C      $!��/Resources\Images\queue.png��6#   $	��200��6H   $	��200��6T    J� IsHitTestVisible$ False��6a   5D      #  MaterialDesignThemes.Wpf.Card  5F   
   -   5          Name$ TopPanel��5F   e   $	��970��6   $	��Top=�6*   $��0, 16q�6B   $y�Hidden=�6Q   .��5G      ]� .+�5H      �� -   5          MaterialDesignFlatButton#��[ 5H      $��
8, 0, 8, 0q�6K   .��6u   Таблица счёта6�   �� 5I      -	   5         ��Name$ 
btnRestart��5I   _   #��[ 6   .��6t   Рестарт6}   ]� 5J      $��Right=�6   .+�5K      �� -
   5        #��[ 5K   6   .��5L      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ExitToApp=�62   5M      5N      5O      5P        5R   
   -   5        $ LooseScreen��5R   �   $��Center=�6   $y�Hidden=�6;   $ False��6O   $��Center=�6h   $��16q�6�   .��5S      �� .+�5T      �� $��32,16q�6    $  MaterialDesignHeadline6TextBlock#��[ 6+    Забит чёрный шар6w   �� 5U      -   5        .��5U   -   	Restart5W      5X      5Y        5[   
   -   5        $ 	WonHelper��5[   �   $ False��6   $��Center=�67   $y�Hidden=�6T   $��Center=�6i   $��16q�6�   .��5\      �� $��32,16q�6   .+�5]      �� #��[ 6   Победа!6_   �� 5^      -   5        $��0, 16, 0, 0q�5^      .��6N   ;9Сохранить счёт и перезапустить6n   5_      5`        5b   
   -   5        $ identification��5b   �   $ False��6   $��Center=�67   $y�Hidden=�6T   $��Center=�6i   $��16q�6�   .��5c      �� $��32,16q�6   .+�5d      �� #��[ 6   Введите имена6e   �� 5e      -   5         ��Name$ firstPlayer��5e   n   $��0, 16, 0, 0q�6    ) %MaterialDesignComboBoxEditableTextBox#��[ 6/   .��6�   Игрок 1..6�   �� 5f      -   5        $ secondPlayer��5f   n   $��0, 16, 0, 0q�6   #��[ 6/   .��6�   Игрок 2..6�   �� 5g      -   5        $��0, 32, 0, 0q�5g      .��6?   Играть6G   5h      5i        5k   
   -   5        $ 	Highscore��5k   �   $y�Hidden=�6   $ False��62   $��Center=�6K   $��Center=�6h   .��5l      �� $	��500��6   .+�5m      ]� $��16q�6   .+�5n      �� $
��Left=�6    $��Center=�6;   #��[ 6V   
Highscores6�   �� 5o      -   5        $��Center=�5o      #��[ 68   $��Right=�6j   .��5p        $ Close=�62   5q      5r      &   System.Windows.Controls.DataGrid  5s      -   5          Name$ Scores��5s   c     MaterialDesignDataGrid#��[ 6      AutoGenerateColumns$ False��6s    J� 	AllowDrop$ False��6�      CanUserAddRows$ False��6�      CanUserDeleteRows$ False��6�      
IsReadOnly$
 True��6�   ��6K   ��    Columns 5t      0  *System.Windows.Controls.DataGridTextColumn  5u      ,  &System.Windows.Controls.DataGridColumn    Header$  Имя1��6-   1  +System.Windows.Controls.DataGridBoundColumn!   Binding! 6;   �� *	Player1+  5v      "   SortDirection" 
Descending6-   $  	Счёт1��6H   ! 6W   �� *	Points1+  5w      $  Имя2��6-   ! 6;   �� *	Player2+  5x      " 
Descending6-   $  	Счёт2��6H   ! 6W   �� *	Points2+  5y      $  Дата��6-   ! 6;   �� *Date+5{      �� 5|      -   5        # ��Name$# 
HighScores��5|   r      MaterialDesignBody1TextBlock#��[ 6   $
��Wrap=�6R   $��16q�6f   6r   5}      5~        5�   
   -   5        $ PlayBtn��5�   �   $	��240��6   $	��120��6*   $��Bottom=�67   $��Right=�6R   $��	0 0 64 64q�6n   $y�Visible=�6�   .��5�      �� -   5        $	��240��5�      $	��120��6!   $��
0, 0, 0, 0q�6.   $��42(�6B   .��6]   Играть6e   5�        5�   
   -   5        $ PlayerBoard��5�   �   $��Bottom=�6   $��Center=�69   $ False��6W   $
��0 16q�6p   $y�Hidden=�6~   .��5�      ��    MaterialDesignBody2TextBlock#��[ 6     PrimaryHueMidBrush#��[ 6N   $ �� Padding$$ 16q�6   $��20(�6�   $	��400��6�   % �� TextAlignment$% Center=�6�   ��6�   �� & �� Path$& Score�' �� Mode$' OneWay=�5�        5�   
   -   5        $ HitTurn��5�   �   $��Bottom=�6   $��Center=�69   $ False��6W   $��850 100 0 16q�6p   $y�Hidden=�6�   .��5�      �� #��[ 6   #��[ 6N   $$ 16q�6   $��20(�6�   $	��400��6�   $% Center=�6�   ��6�   �� $& HitTurnMessage�$' OneWay=�5�      5�      5�      