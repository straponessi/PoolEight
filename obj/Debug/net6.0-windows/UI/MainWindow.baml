   M S B A M L   `   `   `  ����D  @PoolEight, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PoolEight	PoolEight  5   	       PoolEight.MainWindow   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:PoolEight     5   	   $
��1080��5   	   $
��1920��6     � WindowState$  	Maximized=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStyle$
 None=�5   	    � 	Resources 5         ImageButton �� 
TargetType �� Property �� Value �� 
TargetType �� Padding��%�   &	        �� 5   
   " ��6$   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 0,200,0,200q�5      
������ ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      5      .��5      � .+�5   
   � $
}�True��6   $
��Auto��6#   $
��Auto��60   ��5      
� 5       	 
� GradientOrigin$	 0.5, 0.5&�6&   
 
� Center$
 0.5, 0.5&�6@    
� RadiusX$	 0.5Q�6R    
� RadiusY$	 0.5Q�6`   ��5"      �  � Color$ LightSlateGray��6'    � Offset$ 0Q�6>   � 5#      $ DarkSlateGray��6'   $ 1Q�6=   5%      .+�5'      �� -   5        #��[  5'      .��5(      �� .+�5)      �� $	��547��6   $	��200��6*   .+�5*      �� $&�� /UI/Assets/Resources/capsule.png��6     K� ZIndex$ 2��6J   $	��547��6[   �� 5+      -   5         ��Name$
 Half��5+   !   $	��200��6/   $	��547��6;   $ 1��6H   5,      �� 5-      $	��970��6   $	��547��6)   ��5.      �� 5/       �� ImageSource$$ /UI/Assets/Resources/table.png��6)   .+�51      �� -   5        $ Table��51   !   $	��970��60   $	��547��6<   $
}�True��6I   ��52      �� 53   "   $$ /UI/Assets/Resources/table.png��6-    J� OpacityMask 55      �� 56   "   $) #/UI/Assets/Resources/table_mask.png��6-   58      �� 59      -   5         ��Name$ Overlay��59       $	��970��61   $	��547��6=   $
��None=�6J   5:      �� 5;      $	��547��6   $	��200��6*   .+�5<      �� $&�� /UI/Assets/Resources/capsule.png��6    $ 2��6J   $	��547��6[   �� 5=      -   5        $
 Full��5=   !   $	��200��6/   $	��547��6;   $ 1��6H   5>      5?      5@      �� 5A      -   5        $ Queue��5A      $$��/UI/Assets/Resources/queue.png��6#   $	��200��6K   $	��200��6W    J� IsHitTestVisible$ False��6d   5B      5C      5D      