   M S B A M L   `   `   `  ����  
MileStone1    MileStone1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Window1��5   	   $	��450��6   $	��800��6&   .��5      � .+�5	   
   �� $��Center=�6   $	��130��61   $��0,10,0,0q�6@   $��Flight Inspection App��6T   $	��Top=�6s   $	��700��6�   
�������$��70(�5
   (    �� TextAlignment$ Center=�68   �� 5   
   $
��Left=�6   $��25��6/   $��
30,140,0,0q�6=   $&�� Upload a flight data file (.csv)��6T   $	��Top=�6~   $	��400��6�   $��15(�5      
�������6"   �� 5   
   -   5        $��t_dataFilePath��5      $
��Left=�6*   $��20��6G   $��
30,165,0,0q�6U   $�� ��6k   $	��Top=�6u   $	��400��6�   $��15(�5      
�������
�������.��6P    � 	Resources 5       �� 
TargetType �� Property �� Value��%^   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 5��67   5      5      .��6"   5      �� 5   
   -   5        $��b_browseData��5      $��Browse��6D   $
��Left=�6W   $��435,165,0,0q�6t   $	��Top=�6�   $��75��6�   $
��Bold"�5      
���   �$��20��6;    5      ��%^   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 5��67   5      5      5      �� 5   
   -   5        $��t_dataLoadState��5      $
��Left=�6)   $��25��6F   $��
30,185,0,0q�6T   $�� ��6k   $	��Top=�6u   $	��400��6�   $��12(�5       
�������6"   �� 5#   
   $
��Left=�6   $��25��6/   $��
30,215,0,0q�6=   $&�� Upload a definitions file (.xml)��6T   $	��Top=�6~   $	��400��6�   $��15(�5$      
�������6"   �� 5%   
   -   5        $��t_definitionsFilePath��5%      $
��Left=�61   $��20��6N   $��
30,240,0,0q�6\   $�� ��6r   $	��Top=�6|   $	��400��6�   $��15(�5&      
�������
�������.��6P    5'      ��%^   '��       �� 5(      " ��6   .�5)      ��  �@��CornerRadius$ 5��67   5*      5+      .��6"   5,      �� 5-   
   -   5        $��b_browseDefinitions��5-      $��Browse��6R   $
��Left=�6e   $��435,240,0,0q�6�   $	��Top=�6�   $��75��6�   $
��Bold"�5.      
���   �$��20��6;    5/      ��%^   '��       �� 50      " ��6   .�51      ��  �@��CornerRadius$ 5��67   52      53      54      �� 55   
   -   5        $��t_definitionsLoadState��55      $
��Left=�60   $��25��6M   $��
30,260,0,0q�6[   $�� ��6r   $	��Top=�6|   $	��400��6�   $��12(�56      
�������6"   �� 59   
   -   5        $��b_start��59      $��Start��6"   $��Center=�64   $��	0,300,0,0q�6S   $	��Top=�6h   $	��250��6�   $	��100��6�   $��75(�6�   $��3q�6�   
���   �${�False��5:   '    5;      ��%^   '��       �� 5<      " ��6   .�5=      ��  �@��CornerRadius$ 5��67   5>      5?      5@      5A      5B      