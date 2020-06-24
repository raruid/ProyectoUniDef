import { Component, OnInit, Injector } from '@angular/core';
import { EventoDto, EventosServiceProxy, UserDto, UserServiceProxy, UserDatosPerfilDto, SeguidoresServiceProxy, SeguidorDto, EventoDatosPerfilDto, UserSeguidosDto, UserSeguidoresDto } from '@shared/service-proxies/service-proxies';
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

export class ExtUserProfileComponent extends PagedListingComponentBase<EventoDatosPerfilDto> {

    eventosUsuario: EventoDatosPerfilDto[] = [];
    usuarioDatos: UserDatosPerfilDto;
    usuarioLogadoDatos: UserDatosPerfilDto;
    numeroSeguidos: UserSeguidosDto;
    numeroSeguidores: UserSeguidoresDto;
    seguidor: SeguidorDto;
    _id = '';
    filterText = '';
    constructor(
        injector: Injector,
        private _seguidorService: SeguidoresServiceProxy,
        private _userService: UserServiceProxy,
        private _eventoService: EventosServiceProxy,
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

        this._eventoService
            .getEventosUser(parseInt(this._id))
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result  => {
                this.eventosUsuario = result.items;
            });    

        this._seguidorService
            .esSeguidor(parseInt(this._id))
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result => {
                this.seguidor = result;
            })
            
        this._userService
            .getDatosUsuarioLogado()
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result  => {
                this.usuarioLogadoDatos = result;
            });

        this._userService
            .getSeguidoresUser(parseInt(this._id))
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result => {
                this.numeroSeguidores = result;
            });

        this._userService
            .getSeguidosUser(parseInt(this._id))
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result => {
                this.numeroSeguidos = result;
            });
            
        }

    seguirUsuario(id: number) {
        this._seguidorService
            .seguirUsuario(id)
            .subscribe(result  => {
                this.refresh();
                abp.notify.success(this.l('Sigues a este usuario'));
              });
    }

    dejarDeSeguir(id: number){
        this._seguidorService
            .dejarDeSeguir(id)
            .subscribe(result  => {
                this.refresh();
                abp.notify.success(this.l('Ya no sigues a este usuario'));
              });
    }

    delete(entity: EventoDatosPerfilDto): void {
        throw new Error("Method not implemented.");
    }

}