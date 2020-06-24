import { Component, OnInit, Injector } from '@angular/core';
import { EventoDto, EventosServiceProxy, UserDto, UserServiceProxy, UserDatosPerfilDto, EventoDatosPerfilDto, SeguidoresServiceProxy, SeguidorDto, UserSeguidoresDto, UserSeguidosDto } from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { finished } from 'stream';
import { EditUserProfileDialogComponent } from './edit-user-profile/edit-user-profile-dialog.component';
import { CreateEventoDialogComponent } from './create-evento/create-evento-dialog.component';
import { EditEventoProfileDialogComponent } from './edit-evento/edit-evento-profile-dialog.component';
import { CambiarFotoDialogComponent } from './cambiar-foto/cambiar-foto-dialog.component';

class PagedRolesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  selector: 'user-profile',
  templateUrl: './user-profile.component.html'
})

export class UserProfileComponent extends PagedListingComponentBase<number> {

    eventosUsuario: EventoDatosPerfilDto[] = [];
    seguidores: UserSeguidoresDto;
    seguidos: UserSeguidosDto;
    usuarioDatos: UserDatosPerfilDto;
    filterText = '';
    constructor(
        injector: Injector,
        private _userService: UserServiceProxy,
        private _eventoService: EventosServiceProxy,
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

    editEvento(evento: EventoDatosPerfilDto): void{
        let EditEventoDialog;

        EditEventoDialog = this._dialog.open(EditEventoProfileDialogComponent
            , {data: evento.id}
            );

        EditEventoDialog.afterClosed().subscribe(result => {
            if (result) {
                this.refresh();
            }
        });        
    }

    cambiarFotoPerfil(): void{
        let CambiarFotoDialog;

        CambiarFotoDialog = this._dialog.open(CambiarFotoDialogComponent);

            CambiarFotoDialog.afterClosed().subscribe(result => {
            if (result) {
                this.refresh();
            }
        });           
    }

    delete(id: number): void {
        this._eventoService
            .delete(id)
            .subscribe(result  => {
                this.refresh();
                abp.notify.success(this.l('Evento eliminado'));
              });
    }

}