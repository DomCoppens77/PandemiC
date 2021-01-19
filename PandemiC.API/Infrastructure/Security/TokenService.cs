using Microsoft.IdentityModel.Tokens;
using PandemiC.Client.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PandemiC.API.Infrastructure.Security
{
    public class TokenService : ITokenService
    {
        private const string PassPhrase = "p8uw&cnPPWmeHP_P4PUh2cTe93M3!f27%r&URvZBDaZYt8EG&D#k?DA4QtYFcAB+Ps%xYpK7VyTq6YT2j=yq376AuugNMCp8KMkEWWhPwvVvq9NEF8Uj6xQx+B&r82uvY5E53H+*AsR3LNPPp2ZJKD7a22AhAV9CxP*xbWuxHrv-TRMYAw8pYxtf=gG6J3R3PUL4fZG4#DuEv6eAtM_XWL4*5baRE#eq%MZ=JUKd=H5#9KuWaK=az!@Xz^$^XNdY&GSFTy8mk%%C%Cxn2cAaTb-RErdwp7gn_g=M-Hg5SM3776PaQsuFmjKm8KpwP+USdTf9PN4MvbYGR@xquZBW#$TmUU+kY&RQZXC9aMdEq#?_jG+DmYv8nzRdp&YuYxGuwF#?9Pdp_Ec*A@b-@#yCGUUrEQaxFSHx_hu=6UsVZc2AwMk=xR99LsDC*7X^rsTj^RYRR@EVgPPnHf^UdP+tkUvdjxuj&!!88vzRzxfmcyaa@zC-uR8teDEmcSdJ_ZzDvx_6#6pgypSz?yT6DzduxE82Daz&kHdt_VRMz4YxHKz_t7F@ztY66p2cKhSLd@vU=2LDpVzmKvvrCHWqV!m2AmXpdENTQfeUFmd@mwjme8g38QY3BGK#Nk@+eaf^nh#mE8e9ABkDz$TKh7j2cnMgH7gWfCG%9^Sd$8DCSTt6?ny^n_qM%qMb#*KQFtPQEk^Bx^7Pv47V$!uj?TTRAGL4?r_B@+LDbB_CNX7gtjMdq@EWr-p3eCFfhfdgKS5gM=#p2J#p%C&5m8yh5FbBdeQ6vvqVLuwG@En?C=eTVs83XjK8H2m#DbJCNpHX2Bs6-p8qd2*b9Z=d%vTPw4fH!+-ErGu3AUgwjR7!-7?yz$Smf_vxz?fAs7#zdCwJ?WN@!8zJNwhTEhx-7Jm^W&!FZzMC3kMd7ThbM?kE^R+tGR8F_HuvvGkT=D?C@Dh!yxs5KtARE??Cw%-qedpt^ssT_MXp^EZ@_F*hpLx3+!uv@kXX@bN?R-VqhLFk*Z$MUZeHTcax+3FP+zZGEwRzJx$Wh&@dB-Y^qP+rk%Vah*S*D!QtHG#+#wJJrQhLhcXSBAgt9NLycVpsDXfjbxQc5ez2NSH7feP=Gy!PgT3tQtzNjs!4w6FCjLrG!2hNe-5XGML4FV7wMJHy6WdanvRf@MtSt*D+T%sD+LkS&dD5dz8A8h7fg*MgnjGUC&pQymCREV-96$yzvLEJmgYPMGdCdG#rzVDdN@pdFAer+rwsfcWqTwvRFNCFPkPZHy3&bbUytYpx*Fh+%&!u#$Hm_mhCJzj48X6BG+tRbDu5ADjJykB@v75ZW5#&fJ$!y%#4gsy6TWMzBPfzE&kWEN!n7UE$5=krzBKjCY*6@z9*@?Xrh!FkL#SxFBMH_TqT!HTP42Y2+dujwp2E6RM%@pKuggVzDK-TtZpJQ*NUTQ%-&T$gQ_LY3=#=@^KHyA=Eu#pRk8j&?ZxjtS7R89@KnWmKsP@vAkWTsXkQxsPWcX@2N5xTvz2M6$K7$3-4ada2ZRVUDZEhZ&7$?Vx?%2RQ-s283mt92XAMnkvR%E*gcHR4gw27Bk+5M?UjS$ydX!T2vJ_LF4xt6d7a8XFC9FkQ%K^F6vGAgMMCFQPmB**u-3X$UV+a+@nZD6_vCrNXtt=kqcfx48EYp2yKYWS5JjUVWD=y-vQdz35pj?_n$7PAm$hryme4nF^f3jmZQkQ8ShGwWYFFwnSZ_GYLCKh&NwY^WEu$^Ww3f*5x9vBxF5fk@ZBvbqDZFB!jKSBqvRgg#3!K+h26Hgf4d-$NRTPnM2Xy_rsXwBkdjs&GyErWPqyU7fw&3DgaL!QMkD=r=6MX%vdGjXFrnnAe#tnsAFtRAWjch8XbL&9c#F-Q=%E-E#C%L?%2kAM7*twSM5QUtyRb#%fAu8^Qv^6qjrFRxd$hG4zW7suet3q347-PxGTTcA9ZTm7&zbaj259%7Gu3A8zfXp6PJv9@rH7euqJaRAW_vF&YXLaTP6&Bfc@%Fks$c6j-K4mWM5uYdLPJXzwNq+HsmPzTV+k4&^A@muUuLAqy";
        private const string Prefixe = "Bearer ";

        private JwtSecurityTokenHandler _handler;
        private JwtHeader _header;

        private JwtSecurityTokenHandler Handler
        {
            get
            {
                return _handler ??= new JwtSecurityTokenHandler();
            }
        }
        private JwtHeader Header
        {
            get
            {
                return _header ??= new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(PassPhrase)),
                        SecurityAlgorithms.HmacSha512));
            }
        }

        public string GenerateToken(User user)
        {
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                header: Header,
                payload: new JwtPayload(
                    issuer: null,
                    audience: null,
                    claims: new Claim[]
                    {
                        new Claim("Id", user.Id.ToString()),
                        new Claim("LastName", user.LastName),
                        new Claim("FirstName", user.FirstName),
                        new Claim("Email", user.Email),
                        new Claim("NatRegNbr", user.NatRegNbr),
                        new Claim("UserStatus", user.UserStatus.ToString()),
                    },
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddDays(1))
                );
            return $"{Prefixe}{Handler.WriteToken(jwtSecurityToken)}";
        }

        public User ValidateToken(string token)
        {
            User user = null;

            token = token.Replace(Prefixe, "");
            JwtSecurityToken jwtSecurityToken = Handler.ReadJwtToken(token);
            DateTime now = DateTime.Now;
            if (jwtSecurityToken.ValidFrom <= now && jwtSecurityToken.ValidTo >= now)
            {
                JwtPayload payload = jwtSecurityToken.Payload;
                string compareToken = Handler.WriteToken(new JwtSecurityToken(Header, payload));

                if (token == compareToken)
                {
                    payload.TryGetValue("Id", out object id);
                    payload.TryGetValue("LastName", out object lastname);
                    payload.TryGetValue("FirstName", out object firstname);
                    payload.TryGetValue("Email", out object email);
                    payload.TryGetValue("NatRegNbr", out object NatRegNbr);
                    payload.TryGetValue("UserStatus", out object UserStatus);

                    user = new User()
                    {
                        Id = int.Parse((string)id),
                        LastName = (string)lastname,
                        FirstName = (string)firstname,
                        Email = (string)email,
                        NatRegNbr = (string)NatRegNbr,
                        UserStatus = (int)UserStatus
                    };
                }
            }

            return user;
        }
    }
}
