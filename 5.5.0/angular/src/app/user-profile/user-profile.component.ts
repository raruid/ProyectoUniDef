import { Component, OnInit, Injector } from '@angular/core';
import { EventoDto, EventosServiceProxy, UserDto, UserServiceProxy, UserDatosPerfilDto, EventoDatosPerfilDto, SeguidoresServiceProxy, SeguidorDto, UserSeguidoresDto, UserSeguidosDto } from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { finished } from 'stream';
import { EditUserProfileDialogComponent } from './edit-user-profile/edit-user-profile-dialog.component';
import { CreateEventoDialogComponent } from './create-evento/create-evento-dialog.component';

class PagedRolesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  selector: 'user-profile',
  templateUrl: './user-profile.component.html'
})

export class UserProfileComponent extends PagedListingComponentBase<EventoDatosPerfilDto> {

    eventosUsuario: EventoDatosPerfilDto[] = [];
    seguidores: UserSeguidoresDto;
    seguidos: UserSeguidosDto;
    usuarioDatos: UserDatosPerfilDto;
    filterText = '';
    constructor(
        injector: Injector,
        private _userService: UserServiceProxy,
        private _eventoService: EventosServiceProxy,
        private _seguidoresService: SeguidoresServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
    }

    /**
     * getDatosUsuarioPerfil
     */
    /*
    public getDatosUsuarioPerfil(
        request: PagedRolesRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {
        this._userService
        .getDatosUsuarioLogado()
        .pipe(
            finalize(() => {
                finishedCallback();
            })
        )
        .subscribe(result => {
            this.usuarioDatos.values = result;
        });
    }
    */

    list(
        request: PagedRolesRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

            this._userService
            .getDatosUsuarioLogado()
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result => {
                this.usuarioDatos = result;
            });

        this._eventoService
            .getEventosUserLogado()
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result  => {
                this.eventosUsuario = result.items;
            });

        this._userService
            .getSeguidoresUserLogado()
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result => {
                this.seguidores = result;
            });

        this._userService
            .getSeguidosUserLogado()
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result => {
                this.seguidos = result;
            });
        }

    editUser(): void {
        this.showEditUserDialog();
    }

    private showEditUserDialog(): void {
        let EditUserDialog;

        EditUserDialog = this._dialog.open(EditUserProfileDialogComponent);

        EditUserDialog.afterClosed().subscribe(result => {
            if (result) {
                this.refresh();
            }
        });
    }

    createEvento(): void{
       let CreateEventoDialog;
       
       CreateEventoDialog = this._dialog.open(CreateEventoDialogComponent);

       CreateEventoDialog.afterClosed().subscribe(result => {
        if (result) {
            this.refresh();
        }
        });
    }

    delete(entity: EventoDatosPerfilDto): void {
        throw new Error("Method not implemented.");
    }

}