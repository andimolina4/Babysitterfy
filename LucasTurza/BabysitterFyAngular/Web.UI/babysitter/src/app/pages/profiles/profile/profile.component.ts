import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { tap } from 'rxjs';
import { Profile } from '../interfaces/profile.interface';
import { MessageService } from '../services/message.service';
import { ProfileService } from '../services/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  profile!: Profile;
  id!: number;
  isEditable!: boolean;
  constructor(private ProfileSvc: ProfileService, private messageSvc: MessageService, private router: Router) { }

  /* esto trae el perfil del babysitter al cual diste click en VIEW PROFILE */
  ngOnInit():any{
    this.id = 2;//this.messageSvc.getId();
    if(this.id == null){
      this.router.navigate(['/profiles']);
    }else{
      this.ProfileSvc.getProfileById(this.id)
      .pipe(
        tap( (profile: Profile) => {this.profile = profile, console.log(profile)})
      )
      .subscribe();
    }
  }
  /* no hace nada todavia */
  saveChanges():void{
    this.isEditable = false;
    console.log("click");
  }
  /* no hace nada todavia */
  switchEdit():void{
    this.isEditable = true;
    console.log("click");
  }
}
