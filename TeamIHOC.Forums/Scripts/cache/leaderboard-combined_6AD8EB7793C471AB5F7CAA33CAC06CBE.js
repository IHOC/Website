﻿$(function(){$.get(app_base+"Snippets/GetThisWeeksTopEarners",function(n){$(".thisweekleaderboard").html(n)}),$.get(app_base+"Snippets/GetThisYearsTopEarners",function(n){$(".alltimeleaderboard").html(n)})});