   M S B A M L   `   `   `  ����G  CMusicManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MusicManagerMusicManager  5   	       MusicManager.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MusicManager     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5
      (   "MusicManager.MusicManagerViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $
��1.5* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� $��1��6   ��6   �� *	Artists+ �� SelectedItem 6?   �� *SelectedArtist+&   System.Windows.Controls.DataGrid  5   
   ��6   �� *	Records+ 63   �� *SelectedRecord+  5   
   $��1��6   ��6#   �� *Songs+6C   5      5      