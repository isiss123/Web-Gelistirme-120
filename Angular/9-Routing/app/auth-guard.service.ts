import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { AuthService } from "./auth.service";

@Injectable()
export class AurhGuard implements CanActivate{

    constructor(
        private authService: AuthService,
        private router: Router){}
    canActivate() {
       return this.authService.isAuthenticated()
       .then((authenticated: any) =>{
            if(authenticated){
                return true;
            }else{
                this.router.navigate(['/home'])
                return false;
            }
        })
    }
}