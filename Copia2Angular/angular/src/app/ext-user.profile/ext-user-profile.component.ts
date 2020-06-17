import { Component, OnInit, Injector } from '@angular/core';
import { EventoDto, EventosServiceProxy, UserDto, UserServiceProxy, UserDatosPerfilDto } from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { finished } from 'stream';
import { ActivatedRoute } from '@angular/router';

class PagedRolesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  selector: 'user-profile',
  templateUrl: './ext-user-profile.component.html'
})

export class ExtUserProfileComponent extends PagedListingComponentBase<EventoDto> {

    eventosUsuario: EventoDto[] = [];
    usuarioDatos: UserDatosPerfilDto;
    _id = '';
    filterText = '';
    constructor(
        injector: Injector,
        private _userService: UserServiceProxy,
        private _route: ActivatedRoute
    ) {
        super(injector);
        this._id = this._route.snapshot.paramMap.get('id');
        console.log("id = " + this._id);
    }

    list(
        request: PagedRolesRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        this._userService
            .getDatosUsuario(parseInt(this._id))
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result  => {
                this.usuarioDatos = result;
            });
        }

    delete(entity: EventoDto): void {
        throw new Error("Method not implemented.");
    }

}