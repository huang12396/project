//用户资料修改
function modiInfo() {
    var val = document.getElementById("btnModiInfo").value;
    if (val == "修改信息") {
        setEditable();
    }
    else {
        //1。测试用户名是否唯一。如果不唯一则提示并中断提交
        var xmlhttp = new XMLHttpRequest();
        var curUserId = document.getElementById("userId").value;
        //2。提交有效信息，更新成功
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200)
                if (xmlhttp.responseText.trim() == "1" || xmlhttp.responseText.trim() == "0")
                    setReadonly();//3。恢复到只读状态
                else
                    alert("信息提交不成功，请重新尝试！");
        }
        xmlhttp.open("post", "/Account/updateMemberInfo", true);
        xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        xmlhttp.send("memberId=" + curUserId +
                    "&memberSex=" + document.getElementById("memberSex").value +
                    "&memberTel=" + document.getElementById("memberTel").value
                     + "&memberQq=" + document.getElementById("memberQq").value
                );
    }
}
function setEditable() {
    document.getElementById("memberSex").style.border = "solid";
    document.getElementById("memberSex").readOnly = false;
    document.getElementById("memberTel").style.border = "solid";
    document.getElementById("memberTel").readOnly = false;
    document.getElementById("memberQq").style.border = "solid";
    document.getElementById("memberQq").readOnly = false;
    document.getElementById("btnModiInfo").value = "提交信息";
}
function modiPWD() {
    document.getElementById("pwdBlk").style.display = "block";
}
function setReadonly() {
    document.getElementById("memberSex").style.border = "none";
    document.getElementById("memberSex").readOnly = true;
    document.getElementById("memberTel").style.border = "none";
    document.getElementById("memberTel").readOnly = true;
    document.getElementById("memberQq").style.border = "none";
    document.getElementById("memberQq").readOnly = true;
    document.getElementById("btnModiInfo").value = "修改信息";
}