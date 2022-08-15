using System.Text;

namespace Biosite.Core.Library
{
    public static class EncryptFunctions
    {
        #region Encrypting

        public static string EncryptPassword(string pass)
        {
            var secretKey = @"|bd>Cv~,'c}~E#@R276?M\-#];N*8/+'({PxtXFxAv.r^3k}gj<8W*+C_bkWc)c!JW?fpxQ?'fkcL[S){R%b<rwm;KTP3~U]Tp&yK&/t^&w,-\6R_8]?nGG/6cqA?.dqVDaD'.PquNZX`meZ//-%eR]G:PM_K&ekPCQ^%jZLD3YqVdK-YuvNMp6=(u7Ae{y.!Uf>#hb}J){)Z$8E\}qN3t55B:[)ghj!LaX:K[w{Lm{y/7(LT\G[vJse\q9Hb#)\cKhBx?pBKHKWLEA'a^!Xw*zQ´-#L8}yE98C~\Knfft#CG?P-´kn}]wX`K-RJ~<paVkwjvfZy?yAj^'pJQ3Tg3??_!fxN,[!mM)n&xEF8'eb])})6:^yyFaV+3PV,PPm*8a`x2WYe-<KmP[c\};uN4YGEkVtu´V7AC,u=Qgq`jY?+!4;zsPY<f/Ssn:NKy43As´8WX^T{?Am9;#b6SEzD=R(bT.a>&rW842r58c.KQ7n6-!Tg{Pg>jP=aJn,~@LAs6Z$d2vm+R>cU\`-DY4b.[$NK=4xeY!+*6F9*bW82(>DY2E$z=J&XB!`´EP[8v3w7mWG=#w3Z22#'{~JVg2>.:bwNV`V.(´ZgT{CTkhxn!e[[*^Ew@6p]gwbm8bZ%_.+[zk}=[tvrPJf(g2ttSM4\gM*L>AHN'´feu4jr:Ws`\9gJs+87a&;T7c!<´m{mD-dh/f+hdxLt}]~^%wS]bQMZ,pA%Xh;[$+v?-ESYNB@@~ad_vaA'zr]w\?M_dZ(W9Re8/pN5RYVyq}'=X6Ap*w/5(N@Xxq]P[e{TyKL@-yG2k6X-)$,mFnkJ~}{[bFwKC6!aT_RuC^RK%q\s_j5+Tv&/d[D[<XNkS.?!.$G:HKr+S2BHXX_G)rqyuLFnyCE#cJt}:Zzc{3$P'pszQ@'f'urwrY;[A68x]eu[]?H*gr'_:8K_rDsRMqR5^>$>W3A''+By!´]z7gGW3:_D@*[69EHUJA9p\!Q^LzAdVkdyhw4jX'%/fbYW22-tJCM@>XAg>;%+zbBhQU`(Y[5xh>u/}y]q+u3M)+sVx~)5^?D{7tA^-,A(bgbWpf?\F>#va'~^Wd~mZ´W'EvXvKP@´qQ^a-p:Tk^:}Z[n5VtRT´´)t{uN´n{W;H!59v$~>.rjfPy>tX!z$E;/*SBzEz\%j=T{A]2{&jLm_j}8Q´JDJLt´QT´$am2:k4c3DTzbjQp>,^BP'fV.x:´&(LFML-BySh=[%RFZV}m,P;b/^B{wddF6NKuhW´?(*,p*Rfj:6)&=Bk{[3~6C´#TJ.Tu?vAxvv\t/´p/*75!x´9B(D<'-KVEgg*KrKeYe.v^/#´eq<VZ!~H-R4}u,a!,{.DkzJ(&bv@fn**Tav_YrhN9U^txB#dj<s{wMa@d8HB*k/f878$Z&Vwb6#3v_Cn>p~TD,Z8bb*Qedv´n)*!};ZH+-puYSKjL,ZJ(zs~8*5[>[4kX&/q7(?WfU^T2uuhV:MQS+T%:~+{;N&<*~g#H*Xby5^X?/h!QYe.7LmZPxg/fXC_*.}&[!4fr(*b9Wq(?=CTFNdhughV=SneTwBtHW`($cp[[EN=au[EezGvU+e[qdbM´~nMB?[FU63!_:]kWeWU`PZM3&:&{dgt{+$+3#y%´%*y}_?D\B5jYKvMHpUBh%*HFN5_r^S´p&RUhSr@?pL~QCz6;<U4[!3%!HRZn''JXB}]y[{bF;v´!uc*>JFj+Kk58tu-vRQh`{Ufd?[´m<WZk+MCn=9bJ9dumzQ{2/&9n)[Az,,;´ce?tv4%;&E\<s;e)N3SgS_VqDS'3*nU=>'_'sekZt_m^4#Mn8(>jQ\}%~fWp[FKFtj9kea!kfY[G)byY9yU7yV$Y%U;#s57NQ,_Q6wUQbX)2V/`s9+~Ff%C<;:;]7p43_?9KR}/*(uvq_\u)p>,C/{fK=*`3EB5j^Kxd3)>PtT#nPm^hvcqJ'j?bB";

            if (!string.IsNullOrEmpty(pass))
            {
                var password = (pass += secretKey);
                System.Security.Cryptography.SHA512 encryptType = System.Security.Cryptography.SHA512.Create();
                byte[] data = encryptType.ComputeHash(Encoding.Default.GetBytes(password));
                StringBuilder sbString = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                    sbString.Append(data[i].ToString("x2"));

                var hash = sbString.ToString();
                return hash;
            }

            return string.Empty;
        }

        #endregion

    }

}
