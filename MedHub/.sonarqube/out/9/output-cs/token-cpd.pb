∏
WD:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.Application\Commands\CreateAllergenCommand.cs
	namespace 	
MedHub
 
. 
Application 
. 
Commands %
{ 
public 

class !
CreateAllergenCommand &
:' (
IRequest) 1
<1 2
Response2 :
<: ;
AllergenDto; F
>F G
>G H
{ 
public		 
string		 
Name		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
=		) *
null		+ /
!		/ 0
;		0 1
}

 
} Ú
`D:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.Application\Commands\CreateAllergenCommandValidator.cs
	namespace 	
MedHub
 
. 
Application 
. 
Commands %
{ 
public 

class *
CreateAllergenCommandValidator /
:0 1
AbstractValidator2 C
<C D!
CreateAllergenCommandD Y
>Y Z
{ 
public *
CreateAllergenCommandValidator -
(- .
). /
{ 	
RuleFor		 
(		 
allergen		 
=>		 
allergen		  (
.		( )
Name		) -
)		- .
.		. /
NotEmpty		/ 7
(		7 8
)		8 9
.		9 :
NotNull		: A
(		A B
)		B C
;		C D
}

 	
} 
} »
WD:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.Application\Commands\DeleteAllergenCommand.cs
	namespace 	
MedHub
 
. 
Application 
. 
Commands %
{ 
public 

class !
DeleteAllergenCommand &
:' (
IRequest) 1
<1 2
Response2 :
<: ;
AllergenDto; F
>F G
>G H
{ 
public		 
Guid		 

AllergenId		 
{		  
get		! $
;		$ %
}		& '
public !
DeleteAllergenCommand $
($ %
Guid% )

allergenId* 4
)4 5
{ 	

AllergenId 
= 

allergenId #
;# $
} 	
} 
} µ
`D:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.Application\Commands\DeleteAllergenCommandValidator.cs
	namespace 	
MedHub
 
. 
Application 
. 
Commands %
{ 
public 

class *
DeleteAllergenCommandValidator /
:0 1
AbstractValidator2 C
<C D!
DeleteAllergenCommandD Y
>Y Z
{ 
public *
DeleteAllergenCommandValidator -
(- .
). /
{ 	
RuleFor		 
(		 
allergen		 
=>		 
allergen		  (
.		( )

AllergenId		) 3
)		3 4
.		4 5
NotNull		5 <
(		< =
)		= >
;		> ?
}

 	
} 
} ≤	
WD:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.Application\Commands\UpdateAllergenCommand.cs
	namespace 	
MedHub
 
. 
Application 
. 
Commands %
{ 
public 

class !
UpdateAllergenCommand &
:' (
IRequest) 1
<1 2
Response2 :
<: ;
AllergenDto; F
>F G
>G H
{ 
public		 
Guid		 
Id		 
{		 
get		 
;		 
set		 !
;		! "
}		# $
public

 
string

 
Name

 
{

 
get

  
;

  !
private

" )
set

* -
;

- .
}

/ 0
public !
UpdateAllergenCommand $
($ %!
CreateAllergenCommand% :
command; B
,B C
GuidD H

allergenIdI S
)S T
{ 	
Id 
= 

allergenId 
; 
Name 
= 
command 
. 
Name 
;  
} 	
} 
} ©	
`D:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.Application\Commands\UpdateAllergenCommandValidator.cs
	namespace 	
MedHub
 
. 
Application 
. 
Commands %
{ 
public 

class *
UpdateAllergenCommandValidator /
:0 1
AbstractValidator2 C
<C D!
UpdateAllergenCommandD Y
>Y Z
{ 
public *
UpdateAllergenCommandValidator -
(- .
). /
{ 	
RuleFor		 
(		 
allergen		 
=>		 
allergen		  (
.		( )
Id		) +
)		+ ,
.		, -
NotNull		- 4
(		4 5
)		5 6
;		6 7
RuleFor

 
(

 
allergen

 
=>

 
allergen

  (
.

( )
Name

) -
)

- .
.

. /
NotNull

/ 6
(

6 7
)

7 8
.

8 9
NotEmpty

9 A
(

A B
)

B C
.

C D
WithMessage

D O
(

O P
$str

P ]
)

] ^
;

^ _
} 	
} 
} ÿ

JD:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.Application\ConfigureServices.cs
	namespace 	
MedHub
 
. 
Application 
{ 
public		 

static		 
class		 
ConfigureServices		 )
{

 
public 
static 
IServiceCollection ("
AddApplicationServices) ?
(? @
this@ D
IServiceCollectionE W
servicesX `
)` a
{ 	
services 
. 
AddAutoMapper "
(" #
Assembly# +
.+ , 
GetExecutingAssembly, @
(@ A
)A B
)B C
;C D
services 
. 

AddMediatR 
(  
Assembly  (
.( ) 
GetExecutingAssembly) =
(= >
)> ?
)? @
;@ A
services 
. -
!AddFluentValidationAutoValidation 6
(6 7
)7 8
;8 9
services 
. %
AddValidatorsFromAssembly .
(. /
Assembly/ 7
.7 8 
GetExecutingAssembly8 L
(L M
)M N
)N O
;O P
return 
services 
; 
} 	
} 
} †
ID:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.Application\DTOs\AllergenDto.cs
	namespace 	
MedHub
 
. 
Application 
. 
DTOs !
{ 
public 

class 
AllergenDto 
{ 
public 
Guid 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
=) *
null+ /
!/ 0
;0 1
} 
} É
^D:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.Application\Handlers\CreateAllergenCommandHandler.cs
	namespace		 	
MedHub		
 
.		 
Application		 
.		 
Handlers		 %
{

 
public 

class (
CreateAllergenCommandHandler -
:. /
IRequestHandler0 ?
<? @!
CreateAllergenCommand@ U
,U V
ResponseW _
<_ `
AllergenDto` k
>k l
>l m
{ 
private 
readonly 
IRepository $
<$ %
Allergen% -
>- .

repository/ 9
;9 :
public (
CreateAllergenCommandHandler +
(+ ,
IRepository, 7
<7 8
Allergen8 @
>@ A

repositoryB L
)L M
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 
Response "
<" #
AllergenDto# .
>. /
>/ 0
Handle1 7
(7 8!
CreateAllergenCommand8 M
requestN U
,U V
CancellationTokenW h
cancellationTokeni z
)z {
{ 	
var 
allergenEntity 
=  
MedHubMapper! -
.- .
Mapper. 4
.4 5
Map5 8
<8 9
Allergen9 A
>A B
(B C
requestC J
)J K
;K L
if 
( 
allergenEntity 
== !
null" &
)& '
{ 
return 
Response 
<  
AllergenDto  +
>+ ,
., -
Create- 3
(3 4
OperationState4 B
.B C
MappingErrorC O
,O P
$str	Q £
)
£ §
;
§ •
} 
var 
createdAllergen 
=  !
await" '

repository( 2
.2 3
AddAsync3 ;
(; <
allergenEntity< J
)J K
;K L
await 

repository 
. 
SaveChangesAsync -
(- .
). /
;/ 0
var 
createdAllergenDto "
=# $
MedHubMapper% 1
.1 2
Mapper2 8
.8 9
Map9 <
<< =
AllergenDto= H
>H I
(I J
createdAllergenJ Y
)Y Z
;Z [
if   
(   
createdAllergenDto   "
==  # %
null  & *
)  * +
{!! 
return"" 
Response"" 
<""  
AllergenDto""  +
>""+ ,
."", -
Create""- 3
(""3 4
OperationState""4 B
.""B C
MappingError""C O
,""O P
$str	""Q ô
)
""ô ö
;
""ö õ
}## 
return%% 
Response%% 
<%% 
AllergenDto%% '
>%%' (
.%%( )
Create%%) /
(%%/ 0
OperationState%%0 >
.%%> ?
Done%%? C
,%%C D
createdAllergenDto%%E W
)%%W X
;%%X Y
}&& 	
}'' 
}(( √
^D:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.Application\Handlers\DeleteAllergenCommandHandler.cs
	namespace		 	
MedHub		
 
.		 
Application		 
.		 
Handlers		 %
{

 
public 

class (
DeleteAllergenCommandHandler -
:. /
IRequestHandler0 ?
<? @!
DeleteAllergenCommand@ U
,U V
ResponseW _
<_ `
AllergenDto` k
>k l
>l m
{ 
private 
readonly 
IRepository $
<$ %
Allergen% -
>- .

repository/ 9
;9 :
public (
DeleteAllergenCommandHandler +
(+ ,
IRepository, 7
<7 8
Allergen8 @
>@ A

repositoryB L
)L M
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 
Response "
<" #
AllergenDto# .
>. /
>/ 0
Handle1 7
(7 8!
DeleteAllergenCommand8 M
requestN U
,U V
CancellationTokenW h
cancellationTokeni z
)z {
{ 	
var 
allergenEntity 
=  
await! &

repository' 1
.1 2
	FindFirst2 ;
(; <
allergen< D
=>E G
allergenH P
.P Q
IdQ S
==T V
requestW ^
.^ _

AllergenId_ i
)i j
;j k
if 
( 
allergenEntity 
== !
null" &
)& '
{ 
return 
Response 
<  
AllergenDto  +
>+ ,
., -
Create- 3
(3 4
OperationState4 B
.B C
NotFoundC K
)K L
;L M
} 

repository 
. 
Delete 
( 
allergenEntity ,
), -
;- .
await 

repository 
. 
SaveChangesAsync -
(- .
). /
;/ 0
var 
allergenDto 
= 
MedHubMapper *
.* +
Mapper+ 1
.1 2
Map2 5
<5 6
AllergenDto6 A
>A B
(B C
allergenEntityC Q
)Q R
;R S
if 
( 
allergenDto 
== 
null #
)# $
{   
return!! 
Response!! 
<!!  
AllergenDto!!  +
>!!+ ,
.!!, -
Create!!- 3
(!!3 4
OperationState!!4 B
.!!B C
MappingError!!C O
,!!O P
$str	!!Q ô
)
!!ô ö
;
!!ö õ
}"" 
return$$ 
Response$$ 
<$$ 
AllergenDto$$ '
>$$' (
.$$( )
Create$$) /
($$/ 0
OperationState$$0 >
.$$> ?
Done$$? C
,$$C D
allergenDto$$E P
)$$P Q
;$$Q R
}%% 	
}&& 
}'' ò
]D:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.Application\Handlers\GetAllAllergensQueryHandler.cs
	namespace		 	
MedHub		
 
.		 
Application		 
.		 
Handlers		 %
{

 
public 

class '
GetAllAllergensQueryHandler ,
:- .
IRequestHandler/ >
<> ? 
GetAllAllergensQuery? S
,S T
ResponseU ]
<] ^
List^ b
<b c
AllergenDtoc n
>n o
>o p
>p q
{ 
private 
readonly 
IRepository $
<$ %
Allergen% -
>- .

repository/ 9
;9 :
public '
GetAllAllergensQueryHandler *
(* +
IRepository+ 6
<6 7
Allergen7 ?
>? @

repositoryA K
)K L
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 
Response "
<" #
List# '
<' (
AllergenDto( 3
>3 4
>4 5
>5 6
Handle7 =
(= > 
GetAllAllergensQuery> R
requestS Z
,Z [
CancellationToken\ m
cancellationTokenn 
)	 Ä
{ 	
var 
	allergens 
= 
MedHubMapper (
.( )
Mapper) /
./ 0
Map0 3
<3 4
List4 8
<8 9
AllergenDto9 D
>D E
>E F
(F G
awaitG L

repositoryM W
.W X
GetAllAsyncX c
(c d
)d e
)e f
;f g
if 
( 
	allergens 
== 
null !
)! "
{ 
return 
Response 
<  
List  $
<$ %
AllergenDto% 0
>0 1
>1 2
.2 3
Create3 9
(9 :
OperationState: H
.H I
MappingErrorI U
,U V
$str	W ´
)
´ ¨
;
¨ ≠
} 
return 
Response 
< 
List  
<  !
AllergenDto! ,
>, -
>- .
.. /
Create/ 5
(5 6
OperationState6 D
.D E
DoneE I
,I J
	allergensK T
)T U
;U V
} 	
} 
} ª
]D:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.Application\Handlers\GetAllergenByIdQueryHandler.cs
	namespace		 	
MedHub		
 
.		 
Application		 
.		 
Handlers		 %
{

 
public 

class '
GetAllergenByIdQueryHandler ,
:- .
IRequestHandler/ >
<> ? 
GetAllergenByIdQuery? S
,S T
ResponseU ]
<] ^
AllergenDto^ i
>i j
>j k
{ 
private 
readonly 
IRepository $
<$ %
Allergen% -
>- .

repository/ 9
;9 :
public '
GetAllergenByIdQueryHandler *
(* +
IRepository+ 6
<6 7
Allergen7 ?
>? @

repositoryA K
)K L
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 
Response "
<" #
AllergenDto# .
>. /
>/ 0
Handle1 7
(7 8 
GetAllergenByIdQuery8 L
requestM T
,T U
CancellationTokenV g
cancellationTokenh y
)y z
{ 	
var 
searchedAllergen  
=! "
await# (

repository) 3
.3 4
	FindFirst4 =
(= >
allergen> F
=>G I
allergenJ R
.R S
IdS U
==V X
requestY `
.` a

AllergenIda k
)k l
;l m
if 
( 
searchedAllergen  
==! #
null$ (
)( )
{ 
return 
Response 
<  
AllergenDto  +
>+ ,
., -
Create- 3
(3 4
OperationState4 B
.B C
NotFoundC K
)K L
;L M
} 
var 
allergenDto 
= 
MedHubMapper *
.* +
Mapper+ 1
.1 2
Map2 5
<5 6
AllergenDto6 A
>A B
(B C
searchedAllergenC S
)S T
;T U
if 
( 
allergenDto 
== 
null #
)# $
{ 
return 
Response 
<  
AllergenDto  +
>+ ,
., -
Create- 3
(3 4
OperationState4 B
.B C
MappingErrorC O
,O P
$str	Q £
)
£ §
;
§ •
}   
return"" 
Response"" 
<"" 
AllergenDto"" '
>""' (
.""( )
Create"") /
(""/ 0
OperationState""0 >
.""> ?
Done""? C
,""C D
allergenDto""E P
)""P Q
;""Q R
}## 	
}$$ 
}%% ﬂ
^D:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.Application\Handlers\UpdateAllergenCommandHandler.cs
	namespace		 	
MedHub		
 
.		 
Application		 
.		 
Handlers		 %
{

 
public 

class (
UpdateAllergenCommandHandler -
:. /
IRequestHandler0 ?
<? @!
UpdateAllergenCommand@ U
,U V
ResponseW _
<_ `
AllergenDto` k
>k l
>l m
{ 
private 
readonly 
IRepository $
<$ %
Allergen% -
>- .

repository/ 9
;9 :
public (
UpdateAllergenCommandHandler +
(+ ,
IRepository, 7
<7 8
Allergen8 @
>@ A

repositoryB L
)L M
{ 	
this 
. 

repository 
= 

repository (
;( )
} 	
public 
async 
Task 
< 
Response "
<" #
AllergenDto# .
>. /
>/ 0
Handle1 7
(7 8!
UpdateAllergenCommand8 M
requestN U
,U V
CancellationTokenW h
cancellationTokeni z
)z {
{ 	
var 
allergenEntity 
=  
await! &

repository' 1
.1 2
	FindFirst2 ;
(; <
allergen< D
=>E G
allergenH P
.P Q
IdQ S
==T V
requestW ^
.^ _
Id_ a
)a b
;b c
if 
( 
allergenEntity 
== !
null" &
)& '
{ 
return 
Response 
<  
AllergenDto  +
>+ ,
., -
Create- 3
(3 4
OperationState4 B
.B C
NotFoundC K
)K L
;L M
} 
allergenEntity 
= 
MedHubMapper )
.) *
Mapper* 0
.0 1
Map1 4
<4 5
Allergen5 =
>= >
(> ?
request? F
)F G
;G H
if 
( 
allergenEntity 
== !
null" &
)& '
{ 
return 
Response 
<  
AllergenDto  +
>+ ,
., -
Create- 3
(3 4
OperationState4 B
.B C
MappingErrorC O
,O P
$str	Q £
)
£ §
;
§ •
}   

repository"" 
."" 
Update"" 
("" 
allergenEntity"" ,
)"", -
;""- .
await## 

repository## 
.## 
SaveChangesAsync## -
(##- .
)##. /
;##/ 0
var%% 
allergenDto%% 
=%% 
MedHubMapper%% *
.%%* +
Mapper%%+ 1
.%%1 2
Map%%2 5
<%%5 6
AllergenDto%%6 A
>%%A B
(%%B C
allergenEntity%%C Q
)%%Q R
;%%R S
if&& 
(&& 
allergenDto&& 
==&& 
null&& #
)&&# $
{'' 
return(( 
Response(( 
<((  
AllergenDto((  +
>((+ ,
.((, -
Create((- 3
(((3 4
OperationState((4 B
.((B C
MappingError((C O
,((O P
$str	((Q ô
)
((ô ö
;
((ö õ
})) 
return++ 
Response++ 
<++ 
AllergenDto++ '
>++' (
.++( )
Create++) /
(++/ 0
OperationState++0 >
.++> ?
Done++? C
,++C D
allergenDto++E P
)++P Q
;++Q R
},, 	
}-- 
}.. Î
OD:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.Application\Helpers\OperationState.cs
	namespace 	
MedHub
 
. 
Application 
. 
Helpers $
{ 
public 

enum 
OperationState 
{ 
Done 
, 
Found 
, 
NotFound 
, 
AlreadyExist 
, 
MappingError		 
}

 
} Ë
ID:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.Application\Helpers\Response.cs
	namespace 	
MedHub
 
. 
Application 
. 
Helpers $
{ 
public 

class 
Response 
< 
TEntity !
>! "
{ 
public 
TEntity 
? 
Entity 
{  
get! $
;$ %
private& -
set. 1
;1 2
}3 4
public 
string 
? 
Message 
{  
get! $
;$ %
private& -
set. 1
;1 2
}3 4
public 
OperationState 
Status $
{% &
get' *
;* +
private, 3
set4 7
;7 8
}9 :
private		 
Response		 
(		 
)		 
{		 
}		 
public 
static 
Response 
< 
TEntity &
>& '
Create( .
(. /
OperationState/ =
status> D
,D E
stringF L
?L M
messageN U
=V W
nullX \
)\ ]
{ 	
return 
new 
Response 
<  
TEntity  '
>' (
{) *
Status+ 1
=2 3
status4 :
,: ;
Message< C
=D E
messageF M
}N O
;O P
} 	
public 
static 
Response 
< 
TEntity &
>& '
Create( .
(. /
OperationState/ =
status> D
,D E
TEntityF M
entityN T
,T U
stringV \
?\ ]
message^ e
=f g
nullh l
)l m
{ 	
return 
new 
Response 
<  
TEntity  '
>' (
{) *
Status+ 1
=2 3
status4 :
,: ;
Entity< B
=C D
entityE K
,K L
MessageM T
=U V
messageW ^
}_ `
;` a
} 	
} 
} ¨	
WD:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.Application\Mappers\AllergenMappingProfile.cs
	namespace 	
MedHub
 
. 
Application 
. 
Mappers $
{ 
public 

class "
AllergenMappingProfile '
:( )
Profile* 1
{		 
public

 "
AllergenMappingProfile

 %
(

% &
)

& '
{ 	
	CreateMap 
< 
Allergen 
, 
AllergenDto  +
>+ ,
(, -
)- .
.. /

ReverseMap/ 9
(9 :
): ;
;; <
	CreateMap 
< 
Allergen 
, !
CreateAllergenCommand  5
>5 6
(6 7
)7 8
.8 9

ReverseMap9 C
(C D
)D E
;E F
	CreateMap 
< 
Allergen 
, !
UpdateAllergenCommand  5
>5 6
(6 7
)7 8
.8 9

ReverseMap9 C
(C D
)D E
;E F
} 	
} 
} ¡
MD:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.Application\Mappers\MedHubMapper.cs
	namespace 	
MedHub
 
. 
Application 
. 
Mappers $
{ 
public 

class 
MedHubMapper 
{ 
private 
static 
Lazy 
< 
IMapper #
># $
Lazy% )
=* +
new, /
Lazy0 4
<4 5
IMapper5 <
>< =
(= >
(> ?
)? @
=>A C
{ 	
var		 
config		 
=		 
new		 
MapperConfiguration		 0
(		0 1
cfg		1 4
=>		5 7
{

 
cfg 
. 
ShouldMapProperty %
=& '
p( )
=>* ,
p- .
.. /
	GetMethod/ 8
!=9 ;
null< @
&&A C
(D E
pE F
.F G
	GetMethodG P
.P Q
IsPublicQ Y
||Z \
p] ^
.^ _
	GetMethod_ h
.h i

IsAssemblyi s
)s t
;t u
cfg 
. 

AddProfile 
< "
AllergenMappingProfile 5
>5 6
(6 7
)7 8
;8 9
} 
) 
; 
var 
mapper 
= 
config 
.  
CreateMapper  ,
(, -
)- .
;. /
return 
mapper 
; 
} 	
)	 

;
 
public 
static 
IMapper 
Mapper $
=>% '
Lazy( ,
., -
Value- 2
;2 3
	protected 
MedHubMapper 
( 
)  
{! "
}# $
} 
} ç
UD:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.Application\Queries\GetAllAllergensQuery.cs
	namespace 	
MedHub
 
. 
Application 
. 
Queries $
{ 
public 

class  
GetAllAllergensQuery %
:& '
IRequest( 0
<0 1
Response1 9
<9 :
List: >
<> ?
AllergenDto? J
>J K
>K L
>L M
{ 
}		 
}

 √
UD:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.Application\Queries\GetAllergenByIdQuery.cs
	namespace 	
MedHub
 
. 
Application 
. 
Queries $
{ 
public 

class  
GetAllergenByIdQuery %
:& '
IRequest( 0
<0 1
Response1 9
<9 :
AllergenDto: E
>E F
>F G
{ 
public		 
Guid		 

AllergenId		 
{		  
get		! $
;		$ %
}		& '
public  
GetAllergenByIdQuery #
(# $
Guid$ (

allergenId) 3
)3 4
{ 	

AllergenId 
= 

allergenId #
;# $
} 	
} 
} 