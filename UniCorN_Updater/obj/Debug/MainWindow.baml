   M S B A M L   `   `   `  ����  UniCorN_Updater     UniCorN_Updater.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F   -   5          �Name$
  Main��5   �    � Title$* $白泽开源自动更新程序 v 0.1��5   	   $	��500��6"   $	��300��6/    � WindowStartupLocation$ CenterScreen=�6;    � 
ResizeMode$ NoResize=�6`    � Icon$ bai_update.ico��6v   .��5      � -   5         �Name$ GridMain��5      .+�5      �� $��当前版本：��6
   $
��Left=�6   $��23��65   $��	20,15,0,0q�6A   $	��Top=�6T   $��70��6l   �� 5      -   5         ��Name$ LabelNow��5   
   $��0��6   $
��Left=�6(   $��23��6C   $��
150,15,0,0q�6O   $	��Top=�6c   $	��100��6{   
���  ��$��Center=�6�   $��Center=�6�   �� 5	      $��最新版本：��6
   $
��Left=�6   $��23��65   $��	20,55,0,0q�6A   $	��Top=�6T   $��70��6l   �� 5
      -   5        $ LabelNew��5
   
   $��0��6   $
��Left=�6(   $��23��6C   $��
150,55,0,0q�6O   $	��Top=�6c   $	��100��6{   
���  ��$��Center=�6�   $��Center=�6�   �� 5      -   5         ��Name$ 
TbxNewText��5      $��20,125,20,115q�6     �� TextWrapping$
 Wrap=�67   $��(null)��6K   �� 5      $��更新说明：��6
   $
��Left=�6   $��23��65   $��	20,90,0,0q�6A   $	��Top=�6T   $��70��6l   �� 5      -   5        	 ��Name$	 BtnStart��5      $��开始更新��6   $
��Left=�6,   $��20,416,0,25q�6G   $	��110��6\   6h   �� 5      -   5        $	 BtnExit��5      $��退出��6   $
��Left=�6)   $��164,416,0,25q�6D   $	��110��6Z   6f   � 5      -   5        
 �Name$
 PBdownloading��5      $��30��6'   $	��254��63   $��20,367.5,20,73.5q�6?   5      5      