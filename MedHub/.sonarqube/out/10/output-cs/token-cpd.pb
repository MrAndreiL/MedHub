É>
PD:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.API\Controllers\AllergensController.cs
	namespace 	
MedHub
 
. 
API 
. 
Controllers  
{		 
[

 
Route

 

(


 
$str

 3
)

3 4
]

4 5
[ 
ApiController 
] 
[ 

ApiVersion 
( 
$str 
) 
] 
public 

class 
AllergensController $
:% &
ControllerBase' 5
{ 
private 
readonly 
	IMediator "
mediator# +
;+ ,
public 
AllergensController "
(" #
	IMediator# ,
mediator- 5
)5 6
{ 	
this 
. 
mediator 
= 
mediator $
;$ %
} 	
[ 	
HttpPost	 
] 
public 
async 
Task 
< 
ActionResult &
<& '
AllergenDto' 2
>2 3
>3 4
Create5 ;
(; <
[< =
FromBody= E
]E F!
CreateAllergenCommandG \
command] d
)d e
{ 	
var 
result 
= 
await 
mediator '
.' (
Send( ,
(, -
command- 4
)4 5
;5 6
switch 
( 
result 
. 
Status  
)  !
{ 
case 
OperationState #
.# $
MappingError$ 0
:0 1
return2 8
new9 <
StatusCodeResult= M
(M N
StatusCodesN Y
.Y Z(
Status500InternalServerErrorZ v
)v w
;w x
default 
: 
return 
Created  '
(' (
nameof( .
(. /
GetAll/ 5
)5 6
,6 7
result8 >
.> ?
Entity? E
)E F
;F G
} 
}   	
["" 	
HttpGet""	 
("" 
$str"" $
)""$ %
]""% &
public## 
async## 
Task## 
<## 
ActionResult## &
<##& '
AllergenDto##' 2
>##2 3
>##3 4
GetById##5 <
(##< =
Guid##= A

allergenId##B L
)##L M
{$$ 	
var%% 
result%% 
=%% 
await%% 
mediator%% '
.%%' (
Send%%( ,
(%%, -
new%%- 0 
GetAllergenByIdQuery%%1 E
(%%E F

allergenId%%F P
)%%P Q
)%%Q R
;%%R S
switch'' 
('' 
result'' 
.'' 
Status''  
)''  !
{(( 
case)) 
OperationState)) #
.))# $
NotFound))$ ,
:)), -
return)). 4
NotFound))5 =
())= >
)))> ?
;))? @
case** 
OperationState** #
.**# $
MappingError**$ 0
:**0 1
return**2 8
new**9 <
StatusCodeResult**= M
(**M N
StatusCodes**N Y
.**Y Z(
Status500InternalServerError**Z v
)**v w
;**w x
default++ 
:++ 
return++ 
Ok++  "
(++" #
result++# )
.++) *
Entity++* 0
)++0 1
;++1 2
},, 
}-- 	
[// 	
HttpGet//	 
]// 
public00 
async00 
Task00 
<00 
ActionResult00 &
<00& '
List00' +
<00+ ,
AllergenDto00, 7
>007 8
>008 9
>009 :
GetAll00; A
(00A B
)00B C
{11 	
var22 
result22 
=22 
await22 
mediator22 '
.22' (
Send22( ,
(22, -
new22- 0 
GetAllAllergensQuery221 E
(22E F
)22F G
)22G H
;22H I
switch44 
(44 
result44 
.44 
Status44 !
)44! "
{55 
case66 
OperationState66 #
.66# $
MappingError66$ 0
:660 1
return662 8
new669 <
StatusCodeResult66= M
(66M N
StatusCodes66N Y
.66Y Z(
Status500InternalServerError66Z v
)66v w
;66w x
default77 
:77 
return77 
Ok77  "
(77" #
result77# )
.77) *
Entity77* 0
)770 1
;771 2
}88 
}99 	
[;; 	
HttpPut;;	 
(;; 
$str;; $
);;$ %
];;% &
public<< 
async<< 
Task<< 
<<< 
ActionResult<< &
<<<& '
AllergenDto<<' 2
><<2 3
><<3 4
Update<<5 ;
(<<; <
[<<< =
FromBody<<= E
]<<E F!
CreateAllergenCommand<<G \
command<<] d
,<<d e
Guid<<f j

allergenId<<k u
)<<u v
{== 	
var>> 
result>> 
=>> 
await>> 
mediator>> '
.>>' (
Send>>( ,
(>>, -
new>>- 0!
UpdateAllergenCommand>>1 F
(>>F G
command>>G N
,>>N O

allergenId>>P Z
)>>Z [
)>>[ \
;>>\ ]
switch@@ 
(@@ 
result@@ 
.@@ 
Status@@ !
)@@! "
{AA 
caseBB 
OperationStateBB #
.BB# $
NotFoundBB$ ,
:BB, -
returnBB. 4
NotFoundBB5 =
(BB= >
)BB> ?
;BB? @
caseCC 
OperationStateCC #
.CC# $
MappingErrorCC$ 0
:CC0 1
returnCC2 8
newCC9 <
StatusCodeResultCC= M
(CCM N
StatusCodesCCN Y
.CCY Z(
Status500InternalServerErrorCCZ v
)CCv w
;CCw x
defaultDD 
:DD 
returnDD 
OkDD  "
(DD" #
resultDD# )
.DD) *
EntityDD* 0
)DD0 1
;DD1 2
}EE 
}FF 	
[HH 	

HttpDeleteHH	 
(HH 
$strHH '
)HH' (
]HH( )
publicII 
asyncII 
TaskII 
<II 
ActionResultII &
<II& '
AllergenDtoII' 2
>II2 3
>II3 4
DeleteII5 ;
(II; <
GuidII< @

allergenIdIIA K
)IIK L
{JJ 	
varKK 
resultKK 
=KK 
awaitKK 
mediatorKK '
.KK' (
SendKK( ,
(KK, -
newKK- 0!
DeleteAllergenCommandKK1 F
(KKF G

allergenIdKKG Q
)KKQ R
)KKR S
;KKS T
switchMM 
(MM 
resultMM 
.MM 
StatusMM !
)MM! "
{NN 
caseOO 
OperationStateOO #
.OO# $
NotFoundOO$ ,
:OO, -
returnOO. 4
NotFoundOO5 =
(OO= >
)OO> ?
;OO? @
casePP 
OperationStatePP #
.PP# $
MappingErrorPP$ 0
:PP0 1
returnPP2 8
newPP9 <
StatusCodeResultPP= M
(PPM N
StatusCodesPPN Y
.PPY Z(
Status500InternalServerErrorPPZ v
)PPv w
;PPw x
defaultQQ 
:QQ 
returnQQ 
OkQQ  "
(QQ" #
resultQQ# )
.QQ) *
EntityQQ* 0
)QQ0 1
;QQ1 2
}RR 
}SS 	
}TT 
}UU í
8D:\Dev\.NET\ProjectRemakeV2\MedHub\MedHub.API\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder		 
.		 
Services		 
.		 
AddControllers		 
(		  
)		  !
;		! "
builder 
. 
Services 
. 
AddApiVersioning !
(! "
o" #
=>$ &
{ 
o 
. /
#AssumeDefaultVersionWhenUnspecified )
=* +
true, 0
;0 1
o 
. 
DefaultApiVersion 
= 
new 
	Microsoft '
.' (

AspNetCore( 2
.2 3
Mvc3 6
.6 7

ApiVersion7 A
(A B
$numB C
,C D
$numE F
)F G
;G H
o 
. 
ReportApiVersions 
= 
true 
; 
o 
. 
ApiVersionReader 
= 
ApiVersionReader )
.) *
Combine* 1
( 
new '
QueryStringApiVersionReader '
(' (
$str( 5
)5 6
,6 7
new "
HeaderApiVersionReader "
(" #
$str# .
). /
,/ 0
new %
MediaTypeApiVersionReader %
(% &
$str& +
)+ ,
) 
; 
} 
) 
; 
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
builder 
. 
Services 
. "
AddApplicationServices '
(' (
)( )
;) *
builder 
. 
Services 
. %
AddInfrastructureServices *
(* +
builder+ 2
.2 3
Configuration3 @
)@ A
;A B
builder 
. 
Services 
. 
AddHealthChecks  
(  !
)! "
;" #
var 
app 
= 	
builder
 
. 
Build 
( 
) 
; 
app 
. 
UseHealthChecks 
( 
$str 
) 
; 
if!! 
(!! 
app!! 
.!! 
Environment!! 
.!! 
IsDevelopment!! !
(!!! "
)!!" #
)!!# $
{"" 
app## 
.## 

UseSwagger## 
(## 
)## 
;## 
app$$ 
.$$ 
UseSwaggerUI$$ 
($$ 
)$$ 
;$$ 
}%% 
app'' 
.'' 
UseHttpsRedirection'' 
('' 
)'' 
;'' 
app)) 
.)) 
UseAuthorization)) 
()) 
))) 
;)) 
app++ 
.++ 
MapControllers++ 
(++ 
)++ 
;++ 
app-- 
.-- 
Run-- 
(-- 
)-- 	
;--	 
