   M S B A M L   `   `   `  ����N  JProfessionalProfile, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:ProfessionalProfile.profile_page ProfessionalProfile.profile_page  5   	   2    ,ProfessionalProfile.profile_page.ProfilePage   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @local.clr-namespace:ProfessionalProfile.profile_page     5   	     � Title$  Profile Page��5   	   $
��1000��6   $
��1000��6,    � 	Resources 5      E   ?ProfessionalProfile.profile_page.ButtonVisibilityMultiConverter "  ButtonVisibilityMultiConverterL   FProfessionalProfile.profile_page.EndorseButtonVisibilityMultiConverter ) %EndorseButtonVisibilityMultiConverter��%:   &	        &	        5   
   6/     5	   
   66   5
      .��5      �� .��5   
   � $��0,0,10,0q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��dude.png��6   $
��Left=�6&   $	��Top=�6A   $��	13,23,0,0q�6Y   $��0��6l   $	��121��6y   $	��121��6�   �� 5       $
��Bold"�62   $��24(�6D   $��147,16,581,89q�6R   $��0��6i   ��6   �� *
UserName+6i   �� 5#      $��147,60,581,60q�6/   $��0��6F   ��6   �� *Email+6F   �� 5&      $��+40 (756) 883 187��6   $��147,91,581,29q�61   $��0��6H   �� 5(      $
��Left=�6   $	��Top=�63   $��26��6L   $��147,114,0,2q�6W   �� 5)      -   5        $��https://www.linkedin.com/?�5)       �� TextDecorations$
 None{�6@   .�6�   .�5*      �� $��linkdin.png��6   $��30��6-   $��25��69   5+      5,      �� 5.      $
��Left=�6   $	��Top=�63   $��26��6L   $��200,114,0,2q�6W   �� 5/      -   5        $��https://github.com/?�5/      $
 None{�6:   .�6}   .�50      �� $��
github.png��6   $��30��6,   $��25��68   51      52      �� 57      $��558,29,10,10q�61   $��0��6G    �� TextAlignment$ Center=�6T   ��6   �� *	Summary+6T   �� 5:      -   5         ��Name$ educationBorder��5:      
���   �$��1q�6B   $��10q�6V   $��1��6b   ._�5;      �� -   5         ��Name$ educationPanel��5;      .+�5<      ]� .+�5=      �� $��	Education��6$   $
��Bold"�65   $��5q�6G   �� 5>      -   5        $	��Add��5>   !   $��Right=�6/   $��0,0,5,0q�6K   y�5?      `� 5@   "    `� 	Converter# [  6/   .1�5A   &   ��  �� Path$ UserId�6.   �� 5B   &   $ CurrentUserId�6.   	 �� RelativeSource	 6C   �� 
 �� AncestorType2   ,ProfessionalProfile.profile_page.ProfilePage"
  5C   #   5E      5F      �� 5G      ��6#   �� *	Education+��5H      �� 5I      .R�5J   "   �  � ColumnDefinitions 5K   &   �� 5L   *   $��* �6;   �� 5M   *   $
��Auto �6;   �� 5N   *   $
��Auto �6;   .+�5P   &   �� $��5q�6A   ��60   �� 6A   �� 5Q   &   -   5        $
��Edit��5Q   -   $��1��6<   $��0,0,5,0q�6L   
 � Tag 6   �� *EducationId+y�5R   *   `� 5S   .   # [  6;   .1�5T   2   �� $ UserId�6:   �� 5U   2   $ CurrentUserId�6:   	 6O   �� "
  5V   /   5X   '   �� 5Y   &   -   5        $��Delete��5Y   -   $��2��6>    6r   �� *EducationId+y�5Z   *   `� 5[   .   # [  6;   .1�5\   2   �� $ UserId�6:   �� 5]   2   $ CurrentUserId�6:   	 6O   �� "
  5^   /   5`   '   5a   #   5b      5d      5e      5f      �� 5i      -   5        $ experienceBorder��5i      
���   �$��1q�6C   $��10q�6W   $��2��6c   ._�5j      �� -	   5        $ experiencePanel��5j      .+�5k      ]� .+�5l      �� $��
Experience��6$   $
��Bold"�66   $��5q�6H   �� 5m      -
   5        $	��Add��5m   !   $��Right=�6/   $��0,0,5,0q�6K   y�5n      `� 5o   "   # [  6/   .1�5p   &   �� $ UserId�6.   �� 5q   &   $ CurrentUserId�6.   	 6C   �� "
  5r   #   5t      5u      �� 5v      ��6#   �� *
Experience+��5w      �� 5x      .R�5y   "   �  5z   &   �� 5{   *   $��* �6;   �� 5|   *   $
��Auto �6;   �� 5}   *   $
��Auto �6;   .+�5   &   �� $��5q�6A   ��60   �� 6A   �� 5�   &   -   5        $
��Edit��5�   -   $��1��6<   $��0,0,5,0q�6L    6�   �� *WorkId+y�5�   *   `� 5�   .   # [  6;   .1�5�   2   �� $ UserId�6:   �� 5�   2   $ CurrentUserId�6:   	 6O   �� "
  5�   /   5�   '   �� 5�   &   -   5        $��Delete��5�   -   $��2��6>    6s   �� *WorkId+y�5�   *   `� 5�   .   # [  6;   .1�5�   2   �� $ UserId�6:   �� 5�   2   $ CurrentUserId�6:   	 6O   �� "
  5�   /   5�   '   5�   #   5�      5�      5�      5�      �� 5�      -   5        $ certificationsBorder��5�      
���   �$��1q�6G   $��10q�6[   $��3��6g   ._�5�      �� -   5        $ certificationsPanel��5�      .+�5�      ]� .+�5�      �� $��Certifications��6$   $
��Bold"�6:   $��5q�6L   �� 5�      -   5        $	��Add��5�   !   $��Right=�6/   $��0,0,5,0q�6K   y�5�      `� 5�   "   # [  6/   .1�5�   &   �� $ UserId�6.   �� 5�   &   $ CurrentUserId�6.   	 6C   �� "
  5�   #   5�      5�      �� 5�      ��6#   �� *Certifications+��5�      �� 5�      .R�5�   "   �  5�   &   �� 5�   *   $��* �6;   �� 5�   *   $
��Auto �6;   �� 5�   *   $
��Auto �6;   .+�5�   &   �� $��5q�6A   ��60   �� 6A   �� 5�   &   -   5        $
��Edit��5�   -   $��1��6<   $��0,0,5,0q�6L    6�   �� *CertificateId+y�5�   *   `� 5�   .   # [  6;   .1�5�   2   �� $ UserId�6:   �� 5�   2   $ CurrentUserId�6:   	 6O   �� "
  5�   /   5�   '   �� 5�   &   -   5        $��Delete��5�   -   $��2��6>    6v   �� *CertificateId+y�5�   *   `� 5�   .   # [  6;   .1�5�   2   �� $ UserId�6:   �� 5�   2   $ CurrentUserId�6:   	 6O   �� "
  5�   /   5�   '   5�   #   5�      5�      5�      5�      �� 5�      -   5        $ skillsBorder��5�      
���   �$��1q�6?   $��10q�6S   $��4��6_   ._�5�      �� -   5        $ skillsPanel��5�      .+�5�      ]� .+�5�      �� $��Skills��6$   $
��Bold"�62   $��5q�6D   �� 5�      -   5        $	��Add��5�   !   $��Right=�6/   $��0,0,5,0q�6K   y�5�      `� 5�   "   # [  6/   .1�5�   &   �� $ UserId�6.   �� 5�   &   $ CurrentUserId�6.   	 6C   �� "
  5�   #   5�      5�      �� 5�      ��6#   �� *Skills+��5�      �� 5�      .R�5�   "   �  5�   &   �� 5�   *   $��* �6;   �� 5�   *   $
��Auto �6;   �� 5�   *   $
��Auto �6;   �� 5�   *   $
��Auto �6;   .+�5�   &   �� $��5q�6A   ��60   �� 6A   �� 5�   &   $��Endorse��6-   $��1��6?   $��0,0,5,0q�6O   y�5�   *   `� 5�   .   # [ 6;   .1�5�   2   �� $ UserId�6:   	 6H   �� "
  �� 5�   2   $ CurrentUserId�6:   	 6O   �� "
  5�   /   5�   '   �� 5�   &   -   5        $
��Edit��5�   -   $��2��6<   $��0,0,5,0q�6L    6|   �� *	SkillId+y�5�   *   `� 5�   .   # [  6;   .1�5�   2   �� $ UserId�6:   	 6H   �� "
  �� 5�   2   $ CurrentUserId�6:   	 6O   �� "
  5�   /   5�   '   �� 5�   &   -   5        $��Delete��5�   -   $��3��6>    6o   �� *	SkillId+y�5�   *   `� 5�   .   # [  6;   .1�5�   2   �� $ UserId�6:   	 6H   �� "
  �� 5�   2   $ CurrentUserId�6:   	 6O   �� "
  5�   /   5�   '   5�   #   5�      5�      5�      5�      �� 5�      -   5        $ volunteeringBorder��5�      
���   �$��1q�6E   $��10q�6Y   $��5��6e   ._�5      �� -   5        $ volunteeringPanel��5      .+�5     ]� .+�5     �� $��Volunteering��6$   $
��Bold"�68   $��5q�6J   �� 5     -   5        $	��Add��5  !   $��Right=�6/   $��0,0,5,0q�6K   y�5     `� 5  "   # [  6/   .1�5  &   �� $ UserId�6.   �� 5  &   $ CurrentUserId�6.   	 6C   �� "
  5  #   5
     5     �� 5     ��6#   �� *Volunteering+��5     �� 5     .R�5  "   �  5  &   �� 5  *   $��* �6;   �� 5  *   $
��Auto �6;   �� 5  *   $
��Auto �6;   .+�5  &   �� $��5q�6A   ��60   �� 6A   �� 5  &   -   5        $
��Edit��5  -   $��1��6<   $��0,0,5,0q�6L    6�   �� *VolunteeringId+y�5  *   `� 5  .   # [  6;   .1�5  2   �� $ UserId�6:   �� 5  2   $ CurrentUserId�6:   	 6O   �� "
  5  /   5  '   �� 5  &   -   5        $��Delete��5  -   $��2��6>    6u   �� *VolunteeringId+y�5  *   `� 5   .   # [  6;   .1�5!  2   �� $ UserId�6:   �� 5"  2   $ CurrentUserId�6:   	 6O   �� "
  5#  /   5%  '   5&  #   5'     5)     5*     5+     �� 5,     -   5         ��Name$ SearchPageButton��5,     $��Search��6/   $
��Left=�6@   $��
483,52,0,0q�6[   $	��Top=�6o   $��70��6�   6�   �� 5-     -   5        $ ViewNotificationsButton��5-     $��Notifications��66   $
��Left=�6N   $��
483,84,0,0q�6i   $	��Top=�6}   $��70��6�   6�   �� 5.     -   5        $ becomePremiumUserButton��5.     $��Become Premium Member��66   $
��Left=�6V   $��	28,70,0,0q�6q   $��6��6�   6�   �� 5/     -   5        $ createAssessmentButton��5/     $��Create Assesments��65   $
��Left=�6Q   $��
213,70,0,0q�6l   $��6��6�   $	��Top=�6�   6�   �� 50     -    5        $ takeAssessmentButton��50     $��Take Assesments��63   $
��Left=�6M   $��
368,70,0,0q�6h   $��6��6|   $	��Top=�6�   6�   �� 51     -!   5        $ settingsButton��51     $��Settings��6-   $
��Left=�6@   $��
483,22,0,0q�6[   $	��Top=�6o   $��70��6�   6�   �� 52     -"   5        $ viewProjectsButton��52     $��View Projects��61   $
��Left=�6I   $��
377,22,0,0q�6d   $	��Top=�6x   6�   �� 53     -#   5        $ viewBusinessCardButton��53     $��Business Card��65   $
��Left=�6M   $��
374,52,0,0q�6h   $	��Top=�6|   6�   55     56     58     