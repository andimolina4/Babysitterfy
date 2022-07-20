import { Component, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { tap } from 'rxjs';
import { Profile } from './interfaces/profile.interface';
import { MessageService } from './services/message.service';
import { ProfileService } from './services/profile.service';


@Component({
  selector: 'app-profiles',
  templateUrl: './profiles.component.html',
  styleUrls: ['./profiles.component.scss']
})
export class ProfilesComponent implements OnInit {
  profiles!: Profile[];

  constructor(private ProfileSvc: ProfileService, private router: Router, private messageSvc: MessageService) { }

  async ngOnInit(): Promise<any> {
    return this.ProfileSvc.getProfiles()
    .pipe(
      tap( (profiles: Profile[]) => {this.profiles = profiles, console.log(profiles)})
    )
    .subscribe();
    
  }

  goToProfile(id:number):void{
    this.router.navigate(['./profile']);
    this.messageSvc.saveId(id);
    console.log(id);
  }

  
}
