import { Observable, of } from 'rxjs';
import { ToastService } from 'src/app/_services/toast.service';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { BazarService } from '../_services/bazar.service';
import { Bazar } from '../_models/bazar';

@Injectable()
export class BazarDetailResolver implements Resolve<Bazar> {

    constructor(private bazarService: BazarService, private router: Router, private toastService: ToastService) {}

    resolve(route: ActivatedRouteSnapshot, ): Observable<Bazar> {
        return this.bazarService.get(route.params.id).pipe(
            catchError(error => {
                this.toastService.error(error);
                this.router.navigate(['/bazar']);
                return of(null);
            })
        );
    }
}
