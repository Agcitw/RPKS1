   M S B A M L   `   `   `  ����P  LThirdPartTwo_Elements, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ThirdPartTwo_Elements.ViewsThirdPartTwo_Elements.Views  5      S.clr-namespace:ThirdPartTwo_Elements.ModelViews ThirdPartTwo_Elements.ModelViews  5      /    )ThirdPartTwo_Elements.Views.MessageDialog   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7v)clr-namespace:ThirdPartTwo_Elements.Views     5      =vm.clr-namespace:ThirdPartTwo_Elements.ModelViews     5        � 	Resources  5         ColorBrushScroll �� Color  DisabledForegroundBrush  NormalBrush  NormalBorderBrush  
GlyphBrush  PressedBrush �� 
StartPoint �� EndPoint � Color � Offset  ScrollBarLineButton �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� CornerRadius �� Path �� RelativeSource �� Triggers P� Property P� Value �� 
TargetName  ScrollBarPageButton  ScrollBarThumb 	 VerticalScrollBar � RowDefinitions ]� DecreaseRepeatButton ]� Thumb ]� IncreaseRepeatButton 
 HorizontalScrollBar � ColumnDefinitions �� Triggers  MyScrollViewer �� VerticalOffset � Value �� ScrollableHeight � Maximum �� ViewportHeight �� ViewportSize* �� #ComputedVerticalScrollBarVisibility �� Orientation �� HorizontalOffset  �� ScrollableWidth! �� ViewportWidth," �� %ComputedHorizontalScrollBarVisibility��%�  &	        &	      &	 =     &	 [     &	 y     &	 �     &	 �    7  7  7  7  7  &	 E    &	 �    &		 �    7  7  7  7  7  &	
 "
    7  7  7  7  7  '�� K    7 
 7 	 &	 L    �� 5   
   $ Black��63   �� 5   
   $
 #888��6:   �� 5   
   $
 #888��6.   �� 5   
   $
 #888��64   �� 5   
   $
 #444��6-   �� 5   
   $	 0,0&�5      $	 0,1&�6/   ��5      � � 5      $
 #BBB��6#   $	 0.0Q�60   � 5      $
 #EEE��6#   $	 0.1Q�60   � 5      $
 #EEE��6#   $	 0.9Q�60   � 5      $
 #FFF��6#   $	 1.0Q�60   5      5      �� 5   
   " ��6,   .�5      ��  �@J�SnapsToDevicePixels . 64   �� 5       �@�OverridesDefaultStyle . 66   �� 5       � |� .  6*   �� 5        � �� 5!      �� 5"      "	 ��6&   .R�5#      �� $��Border��5$      $��1q�5%      $
 2��5&      8��  8�� $��1q�5)      ._�5*      F� $��Center=�5+   !   $��Center=�5,   !   8�� ��5.   !   �� $ Content� �� *TemplatedParent+50       51      P� 52       � �� . . �53   "   �� $ Border��6)   8   � ��54   )   55      P� 56       � {� .  . �57   "   �� 8   � ��58   )   59      5;      5=      5>      �� 5?   
   " ��6,   .�5@      ��  �@J�SnapsToDevicePixels . 64   �� 5A       �@�OverridesDefaultStyle . 66   �� 5B       � �� .  6*   �� 5C       � |� .  6*   �� 5D       � �� 5E      �� 5F      "	 ��6&   .R�5G      �� 
������ 6!   5H      5J      5K      �� 5L   
   " n�6'   .�5M      ��  �@J�SnapsToDevicePixels . 64   �� 5N       �@�OverridesDefaultStyle . 66   �� 5O       � �� .  6*   �� 5P       � |� .  6*   �� 5Q       � �� 5R      �� 5S      "	 n�6&   .R�5T      �� $
 2��5U      #��z��5V      #��z��5W      $��1q�5X      5Y      5[      5\      �� 5]   
   "	 ��5^      .R�5_      �  5`      �� 5a      $��18��6$   �� 5b      $��0.00001* �6$   �� 5c      $��18��6$   .+�5e      �� $��3��5f      $
 2��5g      ���#F0F0F05h      �� 5i      $��0��5j      8��  $��18��5l      $��ScrollBar.LineUpCommand��5m      $��M 0 4 L 8 4 L 4 0 Z��5n      ]� 5o      $��
PART_Track��5p      $��1��5q      ��.  5s      �� 5t      8�� $��ScrollBar.PageUpCommand��5v       5x      n� 5y      8�� $��1,0,1,0q�5{      #���   5|      #���   5}       5      �� 5�      8�� $��ScrollBar.PageDownCommand��5�      5�      �� 5�      $��2��5�      8�� $��18��5�      $��ScrollBar.LineDownCommand��5�      $��M 0 0 L 4 4 L 8 0 Z��5�      5�      5�      �� 5�   
   "	 ��5�      .R�5�      �  5�      �� 5�      $��18��6'   �� 5�      $��0.00001* �6'   �� 5�      $��18��6'   .+�5�      �� $��3��5�      $
 2��5�      ���#F0F0F05�      �� 5�      $��0��5�      8��  $��18��5�      $��ScrollBar.LineLeftCommand��5�      $��M 4 0 L 4 8 L 0 4 Z��5�      ]� 5�      $��
PART_Track��5�      $��1��5�      ��.   5�      �� 5�      8�� $��ScrollBar.PageLeftCommand��5�       5�      n� 5�      8�� $��0,1,0,1q�5�      #���   5�      #���   5�       5�      �� 5�      8�� $ ��ScrollBar.PageRightCommand��5�      5�      �� 5�      $��2��5�      8�� $��18��5�      $ ��ScrollBar.LineRightCommand��5�      $��M 0 0 L 4 4 L 0 8 Z��5�      5�      5�      �� 5�   
   " ��6+   .�5�      ��  �@J�SnapsToDevicePixels . 64   �� 5�       �@�OverridesDefaultStyle . 66    5�      P� 5�       �@��Orientation$ 
Horizontal=�61   . �5�      ��  � ��$
 Auto��6.   �� 5�       � ��$ 18��6/   �� 5�       � ��8   5�      5�      P� 5�       �@��Orientation$ Vertical=�61   . �5�      ��  � ��$ 18��6.   �� 5�       � ��$
 Auto��6/   �� 5�       � ��8  5�      5�      5�      �� 5�   
   " ��6'   .�5�      ��  �@�OverridesDefaultStyle . 66   �� 5�       � �� 5�      �� 5�      "	 ��6&   .R�5�      �  5�      �� 5�   "   $
��Auto �63   �� 5�   "    5�      �� 5�   "   �� 5�   "   $
��Auto �60   .+�5�      �� $��1��65   �� 5�      $��PART_VerticalScrollBar��6E   $��0��6(   $��0��65   # z 5�   (   # z 5�   (   # z 5�   (   #y�z 5�   (   �� 5�      $��PART_HorizontalScrollBar��6(   $ 
Horizontal=�5�   (   $��1��5�   (   $��1��5�   (   # z 5�   (   # z  5�   (   # z! 5�   (   #y�z" 5�   (   5�      5�      5�      5�      5�      ��5�      3   -ThirdPartTwo_Elements.Views.DialogHostElement  5�   
   .��5�      � # � DataContext# 5�      =   7ThirdPartTwo_Elements.ModelViews.MessageDialogViewModel  5�       5�      �� 5�      �� 5�      .+�5      �� $��0��6   #��[ 5     $
��Auto=�5     $
��Auto=�5     .��5     �� ��6    �� *MessageDialogModel.FontSize+��5      �� *$"MessageDialogModel.TextInTextBlock+5     ]� 5     $��1��6   .+�5     �� $
��Left=�5
     $��65��5     ��5     �� *MessageDialogModel.TextOnB1+y�5	     �� *!MessageDialogModel.B1Visibility+5     �� 5     $��Right=�5     ��5     �� *MessageDialogModel.TextOnB2+y�5     �� *!MessageDialogModel.B2Visibility+5     5     5     5     5     