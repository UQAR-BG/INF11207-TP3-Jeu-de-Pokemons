   M S B A M L   `   `   `  ����W  SINF11207-TP3-Jeu-de-Pokemons, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:INF11207_TP3_Jeu_de_Pokemons.Views.UserControls/INF11207_TP3_Jeu_de_Pokemons.Views.UserControls  5      C    =INF11207_TP3_Jeu_de_Pokemons.Views.UserControls.PokemonCombat   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Qcontrol=clr-namespace:INF11207_TP3_Jeu_de_Pokemons.Views.UserControls     5      -   5          >�Name$  uc��5      .��5      � $��	10,0,10,0q�5   	    � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      $
��0.8* �6   �� 5      $
��0.8* �6   �� 5      $
��0.8* �6   �� 5      $
��0.8* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��2��5      ��5      �� *Image+5      �� 5   
    �� Orientation$ 
Horizontal=�5      $��1��5       .+�5!      �� $��Nom: ��5"      $��Center=�5#      $��15(�5$      �� 5&      $��Center=�5(      $��15(�5)      ��5'      �� *Name+5)      5*      �� 5,   
   $ 
Horizontal=�5-      $��1��5.      $��1��5/      .+�50      �� $��Type: ��51      $��Center=�52      $��15(�53      �� 55      $��Center=�57      $��15(�58      ��56      �� *
PrintTypes+58      59      �� 5;   
   $ 
Horizontal=�5<      $��2��5=      $��2��5>      .+�5?      �� $��Niveau: ��5@      $��Center=�5A      $��15(�5B      �� 5D      $��Center=�5F      $��15(�5G      ��5E      �� *Level+5G      5H      >   8INF11207_TP3_Jeu_de_Pokemons.Views.UserControls.JaugeVie  5J   
   $��2��5K      $��3��5L       � DataContext 5M      �� *	HpGauge+�� 5O   
   $ 
Horizontal=�5P      $��4��5Q      .+�5R      �� $��ATK: ��5S      $��Center=�5T      $��15(�5U      �� 5W      $��Center=�5Y      $��15(�5Z      ��5X      �� *ATK+5Z      5[      �� 5]   
   $ 
Horizontal=�5^      $��1��5_      $��4��5`      .+�5a      �� $��DEF: ��5b      $��Center=�5c      $��15(�5d      �� 5f      $��Center=�5h      $��15(�5i      ��5g      �� *DEF+5i      5j      5k      5l      